using BaseFormLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeleSharp.TL;
using TeleSharp.TL.Contacts;
using TeleSharp.TL.Upload;
using TLSharp.Core;
using Google.Apis.Auth.OAuth2;
using System.Net;
using Google.Apis.Services;
using System.Net.Http;
using System.Net.Http.Headers;
using Google.Apis.PeopleService.v1;
using Google.Apis.PeopleService.v1.Data;
using ERECRUITMENT_BROADCASTER.Model;

namespace ERECRUITMENT_BROADCASTER
{
    public partial class ContactManagement : _BaseForm
    {
        private String m_client_secret = "aEstJOf8EWSm7nyK3XR8hBhB";
        private String m_client_id = "972873888406-3n8hdtf1hcvu148nfh0p6btrbkma064r.apps.googleusercontent.com";
        public ContactManagement()
        {
            InitializeComponent();
        }
        private void ContactManagement_Load(object sender, EventArgs e)
        {
            SP_GET_BATCHLIST_2();
            button1.Enabled = false;
            button3.Enabled = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                progressBar1.Maximum = (dataGridView1.Rows.Count);
                button1.Enabled = false;
                int row = (dataGridView1.Rows.Count - 1);
                for (int i = 0; i <= row; i++)
                {
                    string GivenName = "";
                    string FamilyName = "";
                    string FullName = dataGridView1.Rows[i].Cells[0].Value.ToString();

                    int wordCount = 0, index = 0;
                    while (index < FullName.Length && char.IsWhiteSpace(FullName[index]))
                        index++;

                    while (index < FullName.Length)
                    {
                        while (index < FullName.Length && !char.IsWhiteSpace(FullName[index]))
                            index++;
                        wordCount++;
                        while (index < FullName.Length && char.IsWhiteSpace(FullName[index]))
                            index++;
                    }
                    if (wordCount == 1)
                    {
                        GivenName = FullName;
                        FamilyName = FullName;
                    }
                    else
                    {
                        string[] name = FullName.Split(' ');
                        GivenName = name[0].ToString();
                        FamilyName = "";
                        if (string.IsNullOrEmpty(name[1].ToString()))
                        {
                            FamilyName = name[0].ToString();
                        }
                        else
                        {
                            FamilyName = name[1].ToString();
                        }
                    }
                    string PhoneValue = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    progressBar1.Value = i;
                    label1.Text = "UPLOADING...(" + (i + 1).ToString() + "/" + (dataGridView1.Rows.Count).ToString() + ")";
                    CreateContact(GivenName, FamilyName, PhoneValue);
                }
                progressBar1.Value = 0;
                button1.Enabled = true;
                label1.Text = "";

                MessageBox.Show("Uploading to Google Contact Success !", "Success");
            }
            catch (Exception msg)
            {
                progressBar1.Value = 0;
                button1.Enabled = true;
                label1.Text = "";
                MessageBox.Show(msg.Message.ToString() + ", Please delete uploaded data on Google Contact", "Error");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string BatchNo = comboBox1.SelectedValue.ToString();
            SP_GET_BATCHLIST_1(BatchNo);
            button1.Enabled = true;
            dataGridView1.AllowUserToAddRows = false;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            progressBar1.Maximum = (dataGridView2.Rows.Count);
            button1.Enabled = false;
            int row = (dataGridView2.Rows.Count - 1);
            for (int i = 0; i <= row; i++)
            {
                string ResourceName = dataGridView2.Rows[i].Cells[2].Value.ToString();
                DeleteContact(ResourceName);
                progressBar1.Value = i;
                label1.Text = "DELETING...(" + (i + 1).ToString() + "/" + (dataGridView2.Rows.Count).ToString() + ")";
            }
            progressBar1.Value = 0;
            button3.Enabled = true;
            label1.Text = "";
            MessageBox.Show("Deleting all google contact Success !", "Success");
        }
        private void button5_Click(object sender, EventArgs e)
        {
            GetContact();
            button3.Enabled = true;
        }
        public void SP_GET_BATCHLIST_2()
        {
            try
            {
                var Sql = @"EXEC [SP_GET_BATCHLIST_2]";
                Sql = string.Format(Sql);
                DataTable dt = SysUtl.ExecuteDTQuery(Sql, null);
                if (dt.Rows.Count == 0)
                {
                    comboBox1.Items.Clear();
                }
                else
                {
                    comboBox1.DataSource = dt;
                    comboBox1.DisplayMember = "BatchNo";
                    comboBox1.ValueMember = "BatchNo";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        public void SP_GET_BATCHLIST_1(string BatchNo)
        {
            try
            {
                var Sql = @"EXEC [SP_GET_BATCHLIST_1] '" + BatchNo + "'";
                Sql = string.Format(Sql);
                DataTable tUsr = SysUtl.ExecuteDTQuery(Sql, null);
                dataGridView1.DataSource = tUsr;
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.ToString(), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void CreateContact(string GivenName, string FamilyName, string PhoneValue)
        {
            try
            {
                UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                new ClientSecrets
                {
                    ClientId = m_client_id,
                    ClientSecret = m_client_secret
                },
                new[] { "profile", "https://www.googleapis.com/auth/contacts",
                                    "https://www.googleapis.com/auth/contacts.other.readonly",
                                    "https://www.googleapis.com/auth/contacts.readonly",
                                    "https://www.googleapis.com/auth/profile.agerange.read",
                                    "https://www.googleapis.com/auth/profile.language.read",
                                    "https://www.googleapis.com/auth/user.birthday.read",
                                    "https://www.googleapis.com/auth/user.addresses.read",
                                    "https://www.googleapis.com/auth/user.emails.read",
                                    "https://www.googleapis.com/auth/user.gender.read",
                                    "https://www.googleapis.com/auth/user.organization.read",
                                    "https://www.googleapis.com/auth/user.phonenumbers.read",
                                    "https://www.googleapis.com/auth/userinfo.email"}, "me", CancellationToken.None).Result;

                var service = new PeopleServiceService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "ERecruitment Shimano",
                });
                Person contactToCreate = new Person();
                List<Name> names = new List<Name>();
                List<PhoneNumber> phoneNumbers = new List<PhoneNumber>();
                names.Add(new Name()
                {
                    GivenName = GivenName,
                    FamilyName = FamilyName
                });
                phoneNumbers.Add(new PhoneNumber()
                {
                    Value = PhoneValue
                });
                contactToCreate.Names = names;
                contactToCreate.PhoneNumbers = phoneNumbers;
                PeopleResource.CreateContactRequest request = new PeopleResource.CreateContactRequest(service, contactToCreate);
                Person createdContact = request.Execute();
            }
            catch(Exception msg)
            {
                MessageBox.Show(msg.Message.ToString(), "Error On GetContact()");
            }
        }
        public void GetContact()
        {
            try
            {
                UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                new ClientSecrets
                {
                    ClientId = m_client_id,
                    ClientSecret = m_client_secret
                },
                new[] { "profile", "https://www.googleapis.com/auth/contacts",
                                    "https://www.googleapis.com/auth/contacts.other.readonly",
                                    "https://www.googleapis.com/auth/contacts.readonly",
                                    "https://www.googleapis.com/auth/profile.agerange.read",
                                    "https://www.googleapis.com/auth/profile.language.read",
                                    "https://www.googleapis.com/auth/user.birthday.read",
                                    "https://www.googleapis.com/auth/user.addresses.read",
                                    "https://www.googleapis.com/auth/user.emails.read",
                                    "https://www.googleapis.com/auth/user.gender.read",
                                    "https://www.googleapis.com/auth/user.organization.read",
                                    "https://www.googleapis.com/auth/user.phonenumbers.read",
                                    "https://www.googleapis.com/auth/userinfo.email"}, "me", CancellationToken.None).Result;

                var service = new PeopleServiceService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "ERecruitment Shimano",
                });
                ContactGroupsResource groupsResource = new ContactGroupsResource(service);
                ContactGroupsResource.ListRequest listRequest = groupsResource.List();
                ListContactGroupsResponse response = listRequest.Execute();
                List<string> groupNames = new List<string>();
                foreach (ContactGroup group in response.ContactGroups)
                {
                    groupNames.Add(group.FormattedName);
                }
                PeopleResource.ConnectionsResource.ListRequest peopleRequest =
                service.People.Connections.List("people/me");
                //peopleRequest.PersonFields = "names,birthdays,addresses,emailAddresses,phoneNumbers";
                peopleRequest.PersonFields = "names,phoneNumbers";
                peopleRequest.SortOrder = (PeopleResource.ConnectionsResource.ListRequest.SortOrderEnum)1;
                ListConnectionsResponse people = peopleRequest.Execute();
                List<string> contacts = new List<string>();
                List<ModelGoogleContact> GContactList = new List<ModelGoogleContact>();
                var source = new BindingSource();
                if(people.Connections == null)
                {
                    dataGridView2.DataSource = null;
                    MessageBox.Show("No contact found on your Google Account", "Error");
                    button3.Enabled = false;
                }
                else
                {
                    for (int i = 0; i < people.Connections.Count; i++)
                    {
                        ModelGoogleContact GContact = new ModelGoogleContact();

                        var Name = "";
                        var ResourceName = "";
                        var PhoneNumber = "";

                        if (string.IsNullOrEmpty(people.Connections[i].Names[0].DisplayName))
                        {
                            Name = "";
                        }
                        else
                        {
                            Name = people.Connections[i].Names[0].DisplayName.ToString();
                        }


                        if (string.IsNullOrEmpty(people.Connections[i].ResourceName))
                        {
                            ResourceName = "";
                        }
                        else
                        {
                            ResourceName = people.Connections[i].ResourceName.ToString();
                        }


                        if (string.IsNullOrEmpty(people.Connections[i].PhoneNumbers[0].Value))
                        {
                            PhoneNumber = "";
                        }
                        else
                        {
                            PhoneNumber = people.Connections[i].PhoneNumbers[0].Value.ToString();
                        }

                        GContact.Name = Name;
                        GContact.PhoneNumbers = PhoneNumber;
                        GContact.ResourceName = ResourceName;
                        GContactList.Add(GContact);
                    }
                    dataGridView2.DataSource = GContactList;
                    button3.Enabled = true;
                }
            }
            catch (Exception msg)
            {

                MessageBox.Show(msg.ToString(), "Error On GetContact()");
            }
        }
        public void DeleteContact(string ResourceName)
        {
            try
            {
                UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                new ClientSecrets
                {
                    ClientId = m_client_id,
                    ClientSecret = m_client_secret
                },
                new[] { "profile", "https://www.googleapis.com/auth/contacts",
                                    "https://www.googleapis.com/auth/contacts.other.readonly",
                                    "https://www.googleapis.com/auth/contacts.readonly",
                                    "https://www.googleapis.com/auth/profile.agerange.read",
                                    "https://www.googleapis.com/auth/profile.language.read",
                                    "https://www.googleapis.com/auth/user.birthday.read",
                                    "https://www.googleapis.com/auth/user.addresses.read",
                                    "https://www.googleapis.com/auth/user.emails.read",
                                    "https://www.googleapis.com/auth/user.gender.read",
                                    "https://www.googleapis.com/auth/user.organization.read",
                                    "https://www.googleapis.com/auth/user.phonenumbers.read",
                                    "https://www.googleapis.com/auth/userinfo.email"}, "me", CancellationToken.None).Result;

                var service = new PeopleServiceService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "ERecruitment Shimano",
                });
                PeopleResource.DeleteContactRequest request = new PeopleResource.DeleteContactRequest(service, ResourceName);
                request.Execute();
            }
            catch(Exception msg)
            {
                MessageBox.Show(msg.Message.ToString(), "Error on DeleteContact");
            }
        }
    }
}
