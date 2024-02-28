
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTriviaApp.Models;


namespace MyTriviaApp.Services
{
    public class Service
    {
       List<Player> players ;
        List<Question> question ;
        List<Rank> ranks;
        List<Status> status ;
        List<Subject> subject ;
       
        public Service()
        {
            this.players=new List<Player>();
            this.question = new List<Question>();
            this.ranks = new List<Rank>();
            this.status = new List<Status>();
            this.subject = new List<Subject>();
            FillList();
        }

        private void FillList()
        {
            players.Add(new Player { Password = "1234", Name = "Ben" });
            players.Add(new Player { Password = "formula1",Name="Admin" });
            
        }
       
        public bool Login(string user, string pass)
        {

          return  players.Any((x) => x.Name == user && x.Password == pass);
            //for(int i=0;i<user.Count();i++)
            //{
            //    User x= players[i];
            //    if (x.UserName == user && x.Password==pass)
            //        return true;
            //}
            //return false;
        }

        

    }
}
