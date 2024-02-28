
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
        List<Question> questions ;
        List<Rank> ranks;
        List<Status> statuses ;
        List<Subject> subjects ;
       
        public Service()
        {
           this.players=new List<Player>();
            this.questions = new List<Question>();
            this.ranks = new List<Rank>();
            this.statuses = new List<Status>();
            this.subjects = new List<Subject>();
            FillRank();
            FillSubject();
            FillStatus();
            FillPlayers();
            

        }

        private void FillRank()
        {
            ranks.Add(new Rank() {RankId=0,RankName="Admin"});
            ranks.Add(new Rank() { RankId = 0, RankName = "Master" });
            ranks.Add(new Rank() { RankId = 0, RankName = "Rookie" });
        }
        private void FillSubject()
        {
            subjects.Add(new Subject() { SubjectId = 0, SubjectName = "Sport" });
            subjects.Add(new Subject() { SubjectId = 1, SubjectName = "History" });
            subjects.Add(new Subject() { SubjectId = 2, SubjectName = "Politics" });
        }
        private void FillStatus()
        {
            statuses.Add(new Status() { StatusId = 0, Status1 = "Approved" });
            statuses.Add(new Status() { StatusId = 1, Status1 = "Waiting" });
            statuses.Add(new Status() { StatusId = 2, Status1 = "Rejected" });
        }
        private void FillPlayers()
        {
            players.Add(new Player { Mail="Ben.Sha@gmail.com", Name = "Ben", RankId = ranks[0].GetRankId(0), Points = 0, Password = "123", Rank = ranks[0] });
            
            //להוסיף עוד שחקן
        }

       //להוסיף fill questions
       //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!//
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
