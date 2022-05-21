using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Import.Hangfire.Interfaces;
using Import.Hangfire.Models;
using MongoDB.Driver;
using Import.Hangfire.DAO;

namespace Import.Hangfire.Services
{
    public class HangfireJobsService : IHangfireJobsService
    {
        public void ImportarDados()
        {
            var db = ConexaoMongoDB.GetConnection();

            List<string> collections = ConexaoMongoDB.GetCollections(db); 

            foreach (var item in collections)
            {
                var collection = db.GetCollection<DadosHelixModel>(item);
                var results = collection.Find(_ => true);
                int Microcontrolador = int.Parse(item.Substring(collections[0].IndexOf("0"), 4));

                DateTime ultima_hora = Convert.ToDateTime("01/01/2020");
                string nivel = "";
                foreach (var i in results.ToList())
                {
                    if (i.attrName != "TimeInstant")
                    {
                        if (ultima_hora == i.recvTime)
                        {
                            if (i.attrValue == "1")
                            {
                                nivel = i.attrName.Substring(5, 1);
                                continue;
                            }
                            continue;
                        }
                        else if (ultima_hora != Convert.ToDateTime("01/01/2020"))
                        {
                            Console.WriteLine($"{ultima_hora}, nivel: {nivel}, microcontrolador = {Microcontrolador}");

                            var sensor = new SensorModel { idSensor = Microcontrolador, Nivel = int.Parse(nivel), DataHora = Convert.ToDateTime(ultima_hora)};

                            SensorDAO.InsertSensor(sensor);
                            
                            if (i.attrValue == "0")
                            {
                                nivel = "0";
                                ultima_hora = i.recvTime;
                                continue;
                            }
                            else
                            {
                                nivel = i.attrName.Substring(5, 1);
                                ultima_hora = i.recvTime;
                                continue;
                            }
                        }
                        else
                        {
                            if (i.attrValue == "0")
                            {
                                nivel = "0";
                                ultima_hora = i.recvTime;
                                continue;
                            }
                            else
                            {
                                nivel = i.attrName.Substring(5, 1);
                                ultima_hora = i.recvTime;
                                continue;
                            }
                        }
                    }
                }
            }
        }
    }
}
