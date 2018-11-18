using HotelInvatare.Model;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelInvatare.DAL
{
    public class RezervariRepository
    {
        public void Add(RezervareModel rezervare)
        {
            using (var db = new LiteDatabase(@"C:\DataBase\HotelInvatare.db"))
            {
                var rezervari = db.GetCollection<RezervareModel>("rezervare");

                rezervare.Id = rezervari.Count() + 1;

                rezervari.Insert(rezervare);
            }
        }

        public List<RezervareModel> GetAll()
        {
            using (var db = new LiteDatabase(@"C:\DataBase\HotelInvatare.db"))
            {
                var rezervare = db.GetCollection<RezervareModel>("rezervare");

                return rezervare.FindAll().ToList();
            }
        }

        public void Delete(int id)
        {
            using (var db = new LiteDatabase(@"C:\DataBase\HotelInvatare.db"))
            {
                var opinie = db.GetCollection<RezervareModel>("rezervare").Delete(id);
            }
        }

        public RezervareModel GetById(int id)
        {
            using (var db = new LiteDatabase(@"C:\DataBase\HotelInvatare.db"))
            {
                var opinie = db.GetCollection<RezervareModel>("rezervare").FindById(id);
                return opinie;
            }
        }

        public void Update(RezervareModel model)
        {
            using (var db = new LiteDatabase(@"C:\DataBase\HotelInvatare.db"))
            {
                var opinie = db.GetCollection<RezervareModel>("rezervare").Update(model);
            }
        }
    }
}
