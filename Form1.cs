using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using MySql.Data.MySqlClient;
using System.Xml.Linq;
using CsvHelper;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace VoteCalculator
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// change string below to connect your database    v
        /// </summary>
        string connectionString = "server = localhost; database = voters; user = root; password = pass123";

        bool nameBool = false, surBool = false, chartBool = true; // used variables

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string urlCandidates = "http://webtask.future-processing.com:8069/candidates"; // candidates data (XML in JSON)
            string urlBlocked = "http://webtask.future-processing.com:8069/blocked"; //blocked voters data (XML in JSON)
            
            XmlDocument xmlDocCandidates = UrlToXml(urlCandidates);
            XmlDocument xmlDocBlocked = UrlToXml(urlBlocked);
            XmlToSql(xmlDocCandidates, xmlDocBlocked);
            showLogin();
            bindData();

        }

        private void bindData() //binding data with voting result to sataGridView
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                dataGridView.AutoGenerateColumns = false;
                MySqlDataAdapter adapter = new MySqlDataAdapter("select * from candidates", con);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "tbl");
                dataGridView.DataSource = ds.Tables["tbl"];

                dataGridParty.AutoGenerateColumns = false;
                MySqlDataAdapter adapterGropus = new MySqlDataAdapter("select Party, SUM(candidates.votesNumber) as Votes from candidates GROUP BY Party", con);
                DataSet dsGroups = new DataSet();
                adapterGropus.Fill(dsGroups, "tbl");
                dataGridParty.DataSource = dsGroups.Tables["tbl"];
            }
        }

        // Convert XML file downloaded wfom the URL in Json format to XML format
        private XmlDocument UrlToXml (string url)
        {

            ////////////////////////////
            string WEBSERVICE_URL = url;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(WEBSERVICE_URL));
            request.Method = "POST";
            request.ContentType = "application/xml";
            request.Accept = "application/xml";

            XElement redmineRequestXML =
                new XElement("issue",
                new XElement("project_id", 17)
            );

            byte[] bytes = Encoding.UTF8.GetBytes(redmineRequestXML.ToString());

            request.ContentLength = bytes.Length;

            using (Stream putStream = request.GetRequestStream())
            {
                putStream.Write(bytes, 0, bytes.Length);
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string responseFromServer = reader.ReadToEnd();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(responseFromServer);

            return xmlDoc;                  
        }

        // load all data from both url's into MySQL Database
        private void XmlToSql(XmlDocument xmlCandidates,XmlDocument xmlBlocked)
        {
            XmlNodeList candidatesList = xmlCandidates.SelectNodes("/candidates/candidate");
            XmlNodeList blockedList = xmlBlocked.SelectNodes("/disallowed/person");
            string publicDay = xmlCandidates["candidates"]["publicationDate"].InnerText;

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                MySqlCommand candidatesTableCmd = new MySqlCommand("select * from candidates", con);
                try
                {
                    candidatesTableCmd.ExecuteNonQuery();
                }
                catch // <--catch block creates and fills candidates table for the first time. Using few Form simultaneously won't impact candidates table content
                {
                    candidatesTableCmd = new MySqlCommand("create table if not exists candidates(id int not null auto_increment primary key,publicationDay datetime,Name varchar(50),Party varchar(50),votesNumber int default 0)", con);
                    candidatesTableCmd.ExecuteNonQuery();
                    foreach (XmlNode node in candidatesList) // insert candidates into a database once, so it's unchangable
                    {
                        MySqlCommand insertCandidatesCmd = new MySqlCommand("insert into candidates(publicationDay,Name,Party) values('" + publicDay.Trim() + "','" + node["name"].InnerText.Trim() + "','" + node["party"].InnerText.Trim() + "')", con);
                        insertCandidatesCmd.ExecuteNonQuery();
                    }
                    MySqlCommand invalidVotesCommand = new MySqlCommand("insert into candidates(publicationDay,Name,Party) values('" + publicDay.Trim() + "','Invalid votes','Invalid votes')", con);
                    invalidVotesCommand.ExecuteNonQuery();
                }
                MySqlCommand blockedTableCmd = new MySqlCommand("drop table if exists `blocked`; create table blocked(PESEL bigint)",con);
                if(blockedTableCmd.ExecuteNonQuery() == 0)
                {
                    foreach (XmlNode node in blockedList) // insert blocked table from url, every Form launch new table is created, so it can change
                    {
                        MySqlCommand insertBlockedCmd = new MySqlCommand("insert into blocked(PESEL) values(@pesel)",con);
                        insertBlockedCmd.Parameters.AddWithValue("@pesel",Int64.Parse(node["pesel"].InnerText.Trim()));
                        insertBlockedCmd.ExecuteNonQuery();
                    }
                }
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (maskedTextBox.MaskFull && nameBool && surBool)
                LoginEvent();
            else
                MessageBox.Show("Fill all boxes.");
            
        }
        private void LoginEvent()
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();

                if (isPeselOk(maskedTextBox.Text) && isBlocked(maskedTextBox.Text) && isAgeOk(maskedTextBox.Text))
                {

                    MySqlCommand cmd = new MySqlCommand("select count(*) from voter where Name like '"+textBoxName.Text.Trim()+"' and Surname like '"+ textBoxSurname.Text.Trim()+"'  and PESEL = '" + maskedTextBox.Text + "'", con);
                    MySqlCommand cmdPesel = new MySqlCommand("select count(*) from voter where PESEL = '"+maskedTextBox.Text.Trim()+"'",con);
                    int countUser = Convert.ToInt16(cmd.ExecuteScalar());
                    int countPesel = Convert.ToInt16(cmdPesel.ExecuteScalar());
                    if (countUser == 0 && countPesel == 0)
                    {
                        cmd = new MySqlCommand("insert into voter(PESEL,Name,Surname) values('" + maskedTextBox.Text.Trim() + "','" + textBoxName.Text.Trim() + "','" + textBoxSurname.Text.Trim() + "')", con);
                        MessageBox.Show("Login succesful. Your personal data will be used to login next time.");
                    }
                    else if(countUser == 0 && countPesel==1)
                    {
                        MessageBox.Show("User with same PESEL number already exist. Check your Name and Surname.");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Login succesful. Welcome again!");
                    }

                    try
                    {
                        cmd.ExecuteNonQuery();
                        // checking after login, if voter can vote. 
                        //If can, heading to vote panel, if not showing actual voting results
                        if (canVote(maskedTextBox.Text.Trim()))
                            showVote();
                        else
                            showResult();

                        bindData(); // filling dataGridView with data from database
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.ToString());
                    }
                }
            }
        }
        
        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxName.Text.Trim()))
            {
                nameBool = true;
                nameTip.Text = "ok";
            }
            else
            {
                nameBool = false;
                nameTip.Text = "empty";
            }
        }
        private void textBoxSurname_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxSurname.Text.Trim()))
            {
                surBool = true;
                surnameTip.Text = "ok";
            }
            else
            {
                surnameTip.Text = "empty";
                surBool = false;
            }
        }
        private void maskedTextBox_MaskInputRejected_1(object sender, MaskInputRejectedEventArgs e)
        {
            MessageBox.Show("PESEL contains 11 digits!");
        }

        //***************  validation - Pesel correctness, blocked list, age     ***************************
        private bool isPeselOk(string pesel)
        {
            int result = 0; // result of pesel corectness
            for(int i = 0; i<pesel.Length-1; i++)
            {
                if (i % 4 == 0)
                    result += pesel[i] - '0';
                else if (i % 4 == 1)
                    result += (pesel[i] - '0') * 3;
                else if (i % 4 == 2)
                    result += (pesel[i] - '0') * 7;
                else if (i % 4 == 3)
                    result += (pesel[i] - '0') * 9;
            }
            result = 10 - (result % 10);
            if (result == (pesel[10]-'0'))
                return true;
            else
            {
                MessageBox.Show("Invalid PESEL number!");
                return false;
            }
        }

        private bool isBlocked(string pesel)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                MySqlCommand blockedData = new MySqlCommand("select count(*) from blocked where PESEL = '"+pesel+"'", con);
                int count = Convert.ToInt16(blockedData.ExecuteScalar());
                if (count == 0)
                    return true;
                else
                {
                    MessageBox.Show("You can't vote. You are on the black list. Sorry!");
                    return false;
                }           
            }
            
        }

        private bool isAgeOk(string pesel)
        {
            DateTime now = DateTime.Now;
            DateTime adultFrom = new DateTime(now.Year - 18, now.Month, now.Day);
            int day = (int)((pesel[4]-'0')*10 + (pesel[5]-'0'));
            int month = (int)((pesel[2] - '0') * 10 + (pesel[3] - '0'));
            int year = (int)(1900+(pesel[0] - '0') * 10 + (pesel[1] - '0'));
            if (month > 12)
            {
                year += 100;
                month -= 20;
            }
            DateTime bornDay = new DateTime(year, month, day);
            TimeSpan adult = now - adultFrom;
            TimeSpan age = now - bornDay;

            if (adult < age)
                return true;
            else
            {
                MessageBox.Show("You are to young to vote.");
                return false;
            }
            
        }

        //***************  checking, if voter can vote     ***************************
        private bool canVote(string pesel)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();                
                MySqlCommand canVoteCheck = new MySqlCommand("select CanVote from voter where PESEL='" + pesel + "'", con);
                bool count = Convert.ToBoolean(canVoteCheck.ExecuteScalar());
                if (count)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("You already voted!");
                    return false;
                }
                
            }
        }


        private void btnLogout_Click(object sender, EventArgs e)
        {
            showLogin();
        }

        private void btnVote_Click(object sender, EventArgs e)
        {
            showResult();
            int count = 0;
            int index = 0;
            foreach (int indexChecked in checkList.CheckedIndices)
            {
                count++;
                index = indexChecked;
                checkList.SetItemCheckState(indexChecked, CheckState.Unchecked); // unchecking all boxes
            }

          
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                if (count == 1)
                {
                    //add vote OK
                    MySqlCommand cmd = new MySqlCommand("update candidates set votesNumber=votesnumber+1 where id='" + (index+ 1).ToString() + "';", con);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    //invalid vote// invalid login data
                    MySqlCommand cmd = new MySqlCommand("update candidates set votesNumber = votesnumber + 1 where id = 14", con);
                    cmd.ExecuteNonQuery();
                }
                
                MySqlCommand changeCanVote = new MySqlCommand("update voter set CanVote = FALSE where PESEL = " + maskedTextBox.Text.Trim() + "", con);
                changeCanVote.ExecuteNonQuery();
                bindData();
            }

        }

        private void btnChart_Click(object sender, EventArgs e)
        {
            if (chartBool)
            {
                resultChart.Visible = true;
                dataGridView.Visible = false;
                dataGridParty.Visible = false;
                chartBool = !chartBool;
            }
            else
            {
                resultChart.Visible = false;
                dataGridView.Visible = true;
                dataGridParty.Visible = true;
                chartBool = !chartBool;
            }
            //Form1.Width = resultChart.Width;
            
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter("select Name, votesNumber from candidates", con);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "tbl");
                foreach (var series in resultChart.Series)
                {
                    series.Points.Clear();
                }
                foreach (DataRow dr in ds.Tables["tbl"].Rows)
                {
                    
                    resultChart.Series["Results"].Points.AddXY(dr["Name"].ToString(), dr["votesNumber"]);
                }
                resultChart.ChartAreas[0].AxisX.LabelStyle.Angle = -30;
                resultChart.ChartAreas[0].AxisX.Interval = 1;

            }

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter("select Name,Party, votesNumber from candidates", con);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "tbl");
                MySqlDataAdapter adapterGropus = new MySqlDataAdapter("select Party, SUM(candidates.votesNumber) as Votes from candidates GROUP BY Party", con);
                DataSet dsGroups = new DataSet();
                adapterGropus.Fill(dsGroups, "tbl");

                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "CSV file|*.csv | PDF file| *.pdf", ValidateNames = true })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {

                        switch (sfd.FilterIndex)
                        {
                            case 1:
                                using (var sw = new StreamWriter(sfd.FileName))
                                {
                                    StringBuilder sb = new StringBuilder();
                                    sb.AppendLine("Name;Party;Votes");
                                    foreach (DataRow dr in ds.Tables["tbl"].Rows)
                                    {
                                        sb.AppendLine(string.Format("{0};{1};{2}", dr["Name"].ToString(),dr["Party"],dr["votesNumber"]));
                                    }
                                    sb.AppendLine("\n\nParty name;Votes");
                                    foreach (DataRow dr in dsGroups.Tables["tbl"].Rows)
                                    {
                                        sb.AppendLine(string.Format("{0};{1}",dr["Party"].ToString(),dr["Votes"]));
                                    }
                                    sw.Write(sb.ToString());
                                }
                                break;
                            case 2:
                                Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
                                PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.CreateNew));
                                doc.Open();
                                PdfPTable tblCandidates = new PdfPTable(3);

                                tblCandidates.AddCell("Name");
                                tblCandidates.AddCell("Party");
                                tblCandidates.AddCell("Votes");   

                                foreach(DataRow dr in ds.Tables["tbl"].Rows)
                                {
                                    tblCandidates.AddCell(dr["Name"].ToString());
                                    tblCandidates.AddCell(dr["Party"].ToString());
                                    tblCandidates.AddCell(dr["votesNumber"].ToString());
                                }
                                doc.Add(tblCandidates);
                                Paragraph p = new Paragraph("       ");
                                doc.Add(p);
                                PdfPTable tblParty = new PdfPTable(2);
                                tblParty.AddCell("Party");
                                tblParty.AddCell("Votes");
                                foreach (DataRow dr in dsGroups.Tables["tbl"].Rows)
                                {
                                    tblParty.AddCell(dr["Party"].ToString());
                                    tblParty.AddCell(dr["Votes"].ToString());
                                }                               
                                doc.Add(tblParty);
                                doc.Close();
                                break;
                        }
                        
                    }
                }
            }
        }

        // User interface view controls
        private void showLogin()
        {
            checkList.Visible = false;
            btnVote.Visible = false;
            loginPanel.Visible = true;
            dataGridView.Visible = false;
            dataGridParty.Visible = false;
            btnChart.Visible = false;
            btnLogout.Visible = false;
            resultChart.Visible = false;
            btnExport.Visible = false;

            textBoxName.Clear();
            textBoxSurname.Clear();
            maskedTextBox.Clear();
        }
        private void showVote()
        {
            loginPanel.Visible = false;
            btnLogout.Visible = true;
            checkList.Visible = true;
            btnVote.Visible = true;
            dataGridView.Visible = false;
            dataGridParty.Visible = false;
            resultChart.Visible = false;
            btnChart.Visible = false;
            btnExport.Visible = false;
        }
        private void showResult()
        {
            loginPanel.Visible = false;
            btnLogout.Visible = true;
            checkList.Visible = false;
            btnVote.Visible = false;
            dataGridView.Visible = true;
            dataGridParty.Visible = true;
            btnChart.Visible = true;
            resultChart.Visible = false;
            btnExport.Visible = true;
        }


    }
}
