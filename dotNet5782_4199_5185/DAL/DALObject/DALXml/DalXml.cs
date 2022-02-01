using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;
using DalApi;
using System.Xml.Linq;
using System.IO;
using System.Xml.Serialization;

namespace DAL
{
    internal sealed partial class DalXml : IDal
    {
        #region singelton
        static readonly DalXml instance = new DalXml();
        static DalXml() { }
        DalXml() { /*Initialize();*/ }
        public static DalXml Instance { get => instance; }

        #endregion
        string parcelPath = @"ParcelsXml.xml";//XMLSerializer
        string stationPath = @"StationsXml.xml";  //XElement
        string customerPath = @"CustomersXml.xml";//XMLSerializer
        string dronePath = @"DronesXml.xml";//XMLSerializer
        string droneChargePath = @"DroneChargeXml.xml";
        string configPath = @"ConfigXml.xml";
        string usersPath = @"UsersXml.xml";//XMLSerializer




        #region station
        public void AddStation(Station station)
        {
            XElement stationsRoot = XMLTools.LoadListFromXMLElement(stationPath);
            var stationElem = (from stations in stationsRoot.Elements()
                               where stations.Element("ID").Value == station.Id.ToString()
                               select stations).FirstOrDefault();
            if (stationElem != null)
            {
                throw new AlreadyExistsException("station already exist in the system");
            }


            XElement newStation = new("Station",
                new XElement("ID", station.Id),
                new XElement("Name", station.Name),
                new XElement("Longitude", station.Longitude.ToString()),
                new XElement("Lattitude", station.Latitude.ToString()),
                new XElement("ChargeSlots", station.ChargeSlots.ToString()));
            stationsRoot.Add(newStation);
            XMLTools.SaveListToXMLElement(stationsRoot, stationPath);
        }

        public void DeleteStation(int stationID)
        {
            XElement stationsRoot = XMLTools.LoadListFromXMLElement(stationPath);
            var stationElem = (from stations in stationsRoot.Elements()
                               where stations.Element("ID").Value == stationID.ToString()

                               select stations).FirstOrDefault();
            if (stationElem == null)
                throw new AlreadyExistsException("the station dosn't exists");

            stationElem.Remove();
            XMLTools.SaveListToXMLElement(stationsRoot, stationPath);
        }

        public IEnumerable<Station> ReturnStationList(Func<Station, bool> predicate = null)
        {
            List<Station> listOfAllStations = XMLTools.LoadListFromXMLSerializer<Station>(stationPath);
            if (predicate == null)
                return listOfAllStations;
            return listOfAllStations.Where(predicate);


        }

        public Station GetStation(int stationID)
        {
            var listOfStation = XMLTools.LoadListFromXMLSerializer<Station>(stationPath);
            Station station = listOfStation.Find(x => x.Id == stationID);
            if (!listOfStation.Exists(x => x.Id == station.Id))
            {
                throw new NotExistsException("The station doesn't exist in system");
            }
            return station;

        }

        public void UpdateStation(Station station)
        {
            XElement stationsRoot = XMLTools.LoadListFromXMLElement(stationPath);
            XElement stations = (from stationElem in stationsRoot.Elements()
                                 where stationElem.Element("ID").Value == station.Id.ToString()
                                 select stationElem).FirstOrDefault();

            if (stations == null)
                throw new NotExistsException("the station dosn't exists");

            stations.Element("Name").Value = station.Name.ToString();
            stations.Element("ChargeSlots").Value = station.ChargeSlots.ToString();
        }

        public IEnumerable<Station> show_AvailableChargingStations_list()
        {
            XElement stationsRoot = XMLTools.LoadListFromXMLElement(stationPath);
            var stations = (from s in stationsRoot.Elements()
                            select new Station()
                            {
                                Id = Convert.ToInt32(s.Element("ID").Value),
                                ChargeSlots = Convert.ToInt32(s.Element("ChargeSlots").Value),
                                Latitude = Convert.ToDouble(s.Element("Latitude").Value),
                                Longitude = Convert.ToDouble(s.Element("Longitude").Value),
                                Name = s.Element("Name").Value
                            });
            stations = stations.Where(x => x.ChargeSlots > 0);

            return stations;
        }

        #endregion

        #region drone

        public void AddDrone(Drone droneToAdd)
        {
            List<Drone> listOfAllDrones = XMLTools.LoadListFromXMLSerializer<Drone>(dronePath);
            if (listOfAllDrones.Exists(x => x.Id == droneToAdd.Id))
                throw new AlreadyExistsException("The point already axist in the path");

            listOfAllDrones.Add(droneToAdd);
            XMLTools.SaveListToXMLSerializer(listOfAllDrones, dronePath);
        }
        public void UpdateDrone(Drone droneToUpdate)
        {
            List<Drone> listOfAllDrones = XMLTools.LoadListFromXMLSerializer<Drone>(dronePath);
            Drone drone = listOfAllDrones.Find(x => x.Id == droneToUpdate.Id);
            int index = listOfAllDrones.FindIndex(x => x.Id == droneToUpdate.Id);

            if (!listOfAllDrones.Exists(x => x.Id == droneToUpdate.Id))
                throw new NotExistsException("This drone doesn't exist in the system");
            drone.Model = droneToUpdate.Model;
            listOfAllDrones[index] = drone;
            XMLTools.SaveListToXMLSerializer<Drone>(listOfAllDrones, dronePath);
        }


        public void DeleteDrone(int id)
        {
            List<Drone> listOfAllDrones = XMLTools.LoadListFromXMLSerializer<Drone>(dronePath);

            Drone drone = listOfAllDrones.Find(x => x.Id == id);
            if (!listOfAllDrones.Exists(x => x.Id == id))
                throw new NotExistsException("The drone doesn't exist in system");
            listOfAllDrones.Remove(drone);
            XMLTools.SaveListToXMLSerializer<Drone>(listOfAllDrones, dronePath);
        }



        public Drone GetDrone(int id)
        {
            List<Drone> listOfAllDrones = XMLTools.LoadListFromXMLSerializer<Drone>(dronePath);
            Drone drone = listOfAllDrones.Find(x => x.Id == id);
            if (!listOfAllDrones.Exists(x => x.Id == id))
                throw new NotExistsException("The drone in path doesn't exist");
            return drone;
        }

        public IEnumerable<Drone> ReturnDroneList(Func<Drone, bool> predicate = null)
        {
            List<Drone> listOfAllDrones = XMLTools.LoadListFromXMLSerializer<Drone>(dronePath);
            if (predicate == null)
                return listOfAllDrones;
            return listOfAllDrones.Where(predicate);

        }



        #endregion

        #region customer
        public void AddCustomer(Customer customer)
        {
            var listOfCustomer = XMLTools.LoadListFromXMLSerializer<Customer>(customerPath);
            if (listOfCustomer.Exists(x => x.Id == customer.Id))
                throw new AlreadyExistsException("The bus already exist in the system");
            listOfCustomer.Add(customer);
            XMLTools.SaveListToXMLSerializer<Customer>(listOfCustomer, customerPath);
        }

        public void DeleteCustomer(int customerID)
        {
            var listOfCustomer = XMLTools.LoadListFromXMLSerializer<Customer>(customerPath);
            Customer customer = listOfCustomer.Find(x => x.Id == customerID);
            if (!listOfCustomer.Exists(x => x.Id == customer.Id))
                throw new NotExistsException("The customer doesn't exist in system");
            listOfCustomer.Remove(customer);
            XMLTools.SaveListToXMLSerializer<Customer>(listOfCustomer, customerPath);

        }

        public Customer GetCustomer(int customerID)
        {
            var listOfCustomer = XMLTools.LoadListFromXMLSerializer<Customer>(customerPath);
            Customer customer = listOfCustomer.Find(x => x.Id == customerID);
            if (!listOfCustomer.Exists(x => x.Id == customer.Id))

                throw new NotExistsException("The customer doesn't exist in system");
            return customer;
        }



        public IEnumerable<Customer> ReturnCustomerList(Func<Customer, bool> func = null)
        {
            List<Customer> listOfAllDrones = XMLTools.LoadListFromXMLSerializer<Customer>(customerPath);
            if (func == null)
                return listOfAllDrones;
            return listOfAllDrones.Where(func);
        }

        public void UpdateCustomer(Customer customer)
        {
            List<Customer> listOfCustomer = XMLTools.LoadListFromXMLSerializer<Customer>(customerPath);
            Customer myCustomer = listOfCustomer.Find(x => x.Id == customer.Id);
            int index = listOfCustomer.FindIndex(x => x.Id == customer.Id);
            if (!listOfCustomer.Exists(x => x.Id == customer.Id))

                throw new NotExistsException("This customer doesn't exist in the system");


            myCustomer.Id = customer.Id;
            myCustomer.Name = customer.Name;
            myCustomer.Phone = customer.Phone;
            myCustomer.Latitude = customer.Latitude;
            myCustomer.Longitude = customer.Longitude;
            listOfCustomer[index] = myCustomer;

            XMLTools.SaveListToXMLSerializer<Customer>(listOfCustomer, customerPath);
        }

        #endregion

        #region parcel
        public void AddParcel(Parcel parcelToAdd)
        {
            List<Parcel> listOfAllParcels = XMLTools.LoadListFromXMLSerializer<Parcel>(parcelPath);
            if (!listOfAllParcels.Exists(x => x.Id == parcelToAdd.Id))
                throw new AlreadyExistsException("the parcel is alreay exists");
            parcelToAdd.Id = DataSource.Config.RunIdParcel++; //use config.xml
            parcelToAdd.CreationTime = DateTime.Now;
            listOfAllParcels.Add(parcelToAdd);
            XMLTools.SaveListToXMLSerializer<Parcel>(listOfAllParcels, parcelPath);
        }

        public void DeleteParcel(int id)
        {
            XElement parcelRoot = XMLTools.LoadListFromXMLElement(parcelPath);

            XElement parcel = (from p in parcelRoot.Elements()
                               where p.Element("ID").Value == id.ToString()
                               select p).FirstOrDefault();
            if (parcel == null)
                throw new NotExistsException("the data about parcel doesn't exist in system");
            parcel.Remove();
            XMLTools.SaveListToXMLElement(parcelRoot, parcelPath);
        }

        public Parcel GetParcel(int id)
        {
            List<Parcel> listOfAllParcels = XMLTools.LoadListFromXMLSerializer<Parcel>(parcelPath);
            Parcel parcel = listOfAllParcels.Find(x => x.Id == id);
            if (!listOfAllParcels.Exists(x => x.Id == id))
                throw new NotExistsException("The parcel in path doesn't exist");
            return parcel;
        }

        public IEnumerable<Parcel> ReturnParcelList(Func<Parcel, bool> predicate = null)
        {
            List<Parcel> listOfAllParcels = XMLTools.LoadListFromXMLSerializer<Parcel>(parcelPath);
            if (predicate == null)
                return listOfAllParcels;
            return listOfAllParcels.Where(predicate);

        }

        public void UpdateParcel(Parcel parceltoUpdate)
        {
            List<Parcel> listOfAllParcels = XMLTools.LoadListFromXMLSerializer<Parcel>(parcelPath);
            Parcel parcel = listOfAllParcels.Find(x => x.Id == parceltoUpdate.Id);
            int index = listOfAllParcels.FindIndex(x => x.Id == parceltoUpdate.Id);
            if (!listOfAllParcels.Exists(x => x.Id == parceltoUpdate.Id))
                throw new NotExistsException("This parcel doesn't exist in the system");
            parcel.PickedUp = parceltoUpdate.PickedUp;
            parcel.DroneId = parceltoUpdate.DroneId;
            parcel.ParingTime = parceltoUpdate.ParingTime;
            parcel.Priority = parceltoUpdate.Priority;
            parcel.ArrivedTime = parceltoUpdate.ArrivedTime;
            parcel.CreationTime = parceltoUpdate.CreationTime;
            parcel.SenderId = parceltoUpdate.SenderId;
            parcel.TargetId = parceltoUpdate.TargetId;

            listOfAllParcels[index] = parcel;
            XMLTools.SaveListToXMLSerializer<Parcel>(listOfAllParcels, parcelPath);
        }

        public IEnumerable<Parcel> show_UnassignmentParcel_list()
        {
            List<Parcel> listOfAllParcels = XMLTools.LoadListFromXMLSerializer<Parcel>(parcelPath);
            List<Parcel> listOfUnassign = new();

            foreach (Parcel parcel in listOfAllParcels)
            {
                if (parcel.DroneId == 0)
                {
                    listOfUnassign.Add(parcel);
                }
            }
            return listOfUnassign;

        }



        #endregion

        #region droneCharge 

        public DroneINCharge GetDroneInCharge(int id)
        {
            List<DroneINCharge> listOfAllDrones = XMLTools.LoadListFromXMLSerializer<DroneINCharge>(droneChargePath);
            DroneINCharge droneC = listOfAllDrones.Find(x => x.DroneId == id);
            if (!listOfAllDrones.Exists(x => x.DroneId == id))
                throw new NotExistsException("The droneInCharge in path doesn't exist");
            return droneC;

        }


        public IEnumerable<DroneINCharge> ReturnDroneChargeList(Func<DroneINCharge, bool> predicate = null)
        {
            List<DroneINCharge> listOfAllDrones = XMLTools.LoadListFromXMLSerializer<DroneINCharge>(droneChargePath);
            if (predicate == null)
                return listOfAllDrones;
            return listOfAllDrones.Where(predicate);

        }

        public void UpdateRecharge(Station s, Drone d, DateTime chargeTime)
        {

            DroneINCharge DCharge = new();
            List<Station> listOfAllstations = XMLTools.LoadListFromXMLSerializer<Station>(stationPath);
            List<DroneINCharge> listOfAllDroneIncharge = XMLTools.LoadListFromXMLSerializer<DroneINCharge>(droneChargePath);
            int index = listOfAllstations.FindIndex(x => x.Id == s.Id);
            if (listOfAllstations.Exists(x => x.Id == d.Id))
                throw new NotExistsException("The station not exists in the path");

            DCharge.DroneId = d.Id;
            DCharge.StationId = s.Id;
            DCharge.ChargeTime = chargeTime;
            s.ChargeSlots--;


            listOfAllDroneIncharge.Add(DCharge);
            listOfAllstations[index] = s;
            XMLTools.SaveListToXMLSerializer(listOfAllDroneIncharge, droneChargePath);
            XMLTools.SaveListToXMLSerializer(listOfAllstations, stationPath);

        }

        public void UpdateDeleteDroneInCharge(int DroneId)
        {
            List<DroneINCharge> listOfAllDrones = XMLTools.LoadListFromXMLSerializer<DroneINCharge>(droneChargePath);
            DroneINCharge droneC = listOfAllDrones.Find(x => x.DroneId == DroneId);
            if (!listOfAllDrones.Exists(x => x.DroneId == DroneId))
                throw new NotExistsException("The droneInCharge in path doesn't exist");

            listOfAllDrones.Remove(droneC);
        }


        #endregion

        #region General Methods
        public int ReturnParcelStatus(Parcel par)
        {
            if (par.ArrivedTime != null)
            {
                return 3;
            }
            if (par.PickedUp != null)
            {
                return 2;
            }
            if (par.ParingTime != null)
            {
                return 1;
            }
            return 0;
        }

        public double[] PowerConsumptionRequestDrone()
        {
            double[] arr = new double[] { DataSource.Config.Available, DataSource.Config.Light, DataSource.Config.Average, DataSource.Config.Heavy, DataSource.Config.ChargingPaceDrone };

            return arr;
        }


        #endregion
    }
}
