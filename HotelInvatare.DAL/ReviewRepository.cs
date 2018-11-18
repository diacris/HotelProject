using HotelInvatare.Model;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelInvatare.DAL
{
    public class ReviewRepository
    {
        public void Add(ReviewModel opinie)
        {
            using (var db = new LiteDatabase(@"C:\DataBase\HotelInvatare.db"))
            {
                var opinii = db.GetCollection<ReviewModel>("opinie");

                opinie.Id = opinii.Count() + 1;

                opinii.Insert(opinie);
            }
        }

        public List<ReviewModel> GetAll()
        {
            using (var db = new LiteDatabase(@"C:\DataBase\HotelInvatare.db"))
            {
                var opinie = db.GetCollection<ReviewModel>("opinie");

                return opinie.FindAll().ToList();
            }
        }


        public void Delete(int id)
        {
            using (var db = new LiteDatabase(@"C:\DataBase\HotelInvatare.db"))
            {
                var opinie = db.GetCollection<ReviewModel>("opinie").Delete(id);
            }
        }
    }
}
