using HotelInvatare.Model;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelInvatare.DAL
{
    public class CameraRepository
    {
        public void Add(CameraModel camera)
        {
            using (var db = new LiteDatabase(@"C:\DataBase\HotelInvatare.db"))
            {
                var camere = db.GetCollection<CameraModel>("camera");

                camera.Id = camere.Count() + 1;

                camere.Insert(camera);
            }
        }

        public List<CameraModel> GetAll()
        {
            using (var db = new LiteDatabase(@"C:\DataBase\HotelInvatare.db"))
            {
                var camera = db.GetCollection<CameraModel>("camera");

                return camera.FindAll().ToList();
            }
        }

        public int CautaCamereDisponibile(DateTime checkIn, DateTime checkOut, string tip)
        {
            //verific sa fie tip de camera specificat
            if (string.IsNullOrEmpty(tip))
            {
                return 0;
            }
            //verific ca check in-ul sa fie inainte de check out sau in aceeasi zi
            if (DateTime.Compare(checkIn, checkOut) > 0)
            {
                return 0;
            }
            
            using (var db = new LiteDatabase(@"C:\DataBase\HotelInvatare.db"))
            {
                //citesc toate camerele
                var camere = db.GetCollection<CameraModel>("camera");
                //numar cate  camere am de tipul selectat
                var totalCamereTipSelectat = camere.Count(Query.EQ("Tip", tip));
                //citesc toate rezervarile
                var rezervari = db.GetCollection<RezervareModel>("rezervare");
                //filtrez rezervarile numai pt tipul de camera cautat
                var rezervariPeCamere = rezervari.Find(Query.EQ("TipCamera", tip)).ToList();
                //numarul camerelor ocupate este 0, toate camerele sunt disponibele
                int camereOcupate = 0;
                //parcurg toate rezrvarile si vad care sunt in perioada pe care se cauta
                foreach (var rez in rezervariPeCamere)
                {
                    //verific daca rezervarea existenta are chekin-ul dupa sau in ziua de check in cautata si chekot-ul rezervarii existente este dupa checkin-ul cautat 
                    //sau rezervarea existenta are checkout-ul inainte sau in ziua de checkout cautata si checkin-ul rezervarii cautate este inainte sau in ziua checkout-ului
                    if ((DateTime.Compare(rez.CheckIn.Date, checkIn.Date) > -1 && DateTime.Compare(rez.CheckIn.Date, checkOut.Date) < 0)
                        || (DateTime.Compare(rez.CheckOut.Date, checkIn.Date) > 0 && DateTime.Compare(rez.CheckOut.Date, checkOut.Date) < 1))
                    {
                        //incrementez ca am gasit camera ocupata
                        camereOcupate++;
                    }
                }
                //returnez 0 daca cumva datele di sistem sunt inconsistente adica am prea multe rezervari fata de numarul de camere
                if (camereOcupate > totalCamereTipSelectat)
                {
                    return 0;
                }
                //returnez diferenta dintre cate camere am in total de tipul cautat minus camere ocupate de tipul cautat
                return totalCamereTipSelectat - camereOcupate;

            }
        }
    }
}
