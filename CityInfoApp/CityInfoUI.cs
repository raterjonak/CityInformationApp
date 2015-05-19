using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CityInfoApp
{
    public partial class CityInfoUI : Form
    {
        private String connectionString = ConfigurationManager.ConnectionStrings["CityInfoConnString"].ConnectionString;
        public CityInfoUI()
        {
            InitializeComponent();
        }


        City aCity=new City();

        private void saveButton_Click(object sender, EventArgs e)
        {
            aCity.Name = cityNameTextBox.Text;
            aCity.About = aboutTextBox.Text;
            aCity.Country = countryTextBox.Text;

            SqlConnection connection =new SqlConnection(connectionString);

            string query = "Insert Into cityInfo_tbl values('" + aCity.Name + "','" + aCity.About + "','" +
                           aCity.Country + "')";
            SqlCommand command= new SqlCommand(query,connection);

            connection.Open();
            int rawAffected = command.ExecuteNonQuery();
            connection.Close();
            if (rawAffected>0)
            {
                MessageBox.Show("Data saved successfully.");
                ShowAllCity();

            }
            else
            {

                MessageBox.Show("failed");

            }
        }

        public void ShowAllCity()
        {
            SqlConnection connection= new SqlConnection(connectionString);
            string query = "Select * From cityInfo_tbl ";
            SqlCommand command= new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<City> cityList=new List<City>();
            while (reader.Read())
            {
                City cityObj=new City();

                cityObj.Name = reader["city"].ToString();
                cityObj.About = reader["about"].ToString();
                cityObj.Country = reader["country"].ToString();
                cityList.Add(cityObj);

            }
            reader.Close();
            connection.Close();

            LoadCityListView(cityList);
        }

        public void LoadCityListView(List<City> cities)
        {
            int serial = 1;
            cityListView.Items.Clear();
            foreach (var city in cities)
            {
                ListViewItem item=new ListViewItem(serial.ToString());
                item.SubItems.Add(city.Name);
                item.SubItems.Add(city.About);
                item.SubItems.Add(city.Country);

                cityListView.Items.Add(item);

                serial++;
            }  
        }

        private void CityInfoUI_Load(object sender, EventArgs e)
        {
            ShowAllCity();
        }   
    }

}
