using RiotSharp;
using RiotSharp.SummonerEndpoint;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lolwinformtest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

         
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            var api = RiotApi.GetInstance("d254864f-4fda-4807-8e01-6e44b2349ad7");
            Summoner summoner;
            RiotSharp.Region region = RiotSharp.Region.euw;

            try
            {
                summoner = api.GetSummoner(region, summonerTextBox.Text);
                //MessageBox.Show(string.Format("Id : {0} {1}", summoner.Id, "toto"));

                //var matchList = api.GetMatchList(region, summoner.Id, null, );
                var gameList = api.GetRecentGames(region, summoner.Id);
                var masteries = api.GetMasteryPages(region, summoner.Id);

                gameGridView.DataSource = gameList;


            }
            catch (RiotSharpException ex)
            {
                MessageBox.Show(ex.Message);
                // Handle the exception however you want.
            }


        }
    }
}
