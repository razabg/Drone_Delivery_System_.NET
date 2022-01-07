using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
namespace BL
{
    internal sealed partial class BLObject
    {
        /// <summary>
        /// display specific station using the bl station
        /// </summary>
        /// <param name="station_id"></param>
        /// <returns></returns>
        public BaseStation DisplayStation(int station_id)
        {
            int index = AccessToDataMethods.ReturnStationList().ToList().FindIndex(x => x.Id == station_id);
            if (index == -1)
            {
                throw new NotExistsException();
            }
            var DLstationToDisplay = AccessToDataMethods.ReturnStationList().ToList().Find(x => x.Id == station_id);
            IEnumerable<DO.DroneINCharge> DroneINChargeListDal = AccessToDataMethods.ReturnDroneChargeList().Where(x => x.StationId == DLstationToDisplay.Id);
            List<DroneInCharging> droneInChargingList = new List<DroneInCharging>();

            foreach (var drone in ListDroneBL)//create drone in charging list for the station to display
            {
                foreach (var drone_in_charge in DroneINChargeListDal)
                {
                    if (drone.Id == drone_in_charge.DroneId)
                    {
                        droneInChargingList.Add(new DroneInCharging { Battary = drone.Battery, Id = drone.Id });
                    }
                }
            }

            BaseStation BLstation = new BaseStation
            {
                Id = DLstationToDisplay.Id,
                Name = DLstationToDisplay.Name,
                location = new Location(DLstationToDisplay.Longitude, DLstationToDisplay.Latitude),
                DroneINCharge = droneInChargingList,
                NumberOfavailableChargingSlots = DLstationToDisplay.ChargeSlots - droneInChargingList.Count()
            };

            return BLstation;

        }
        public Drone DisplayDrone(int drone_id)
        {
            int index = ListDroneBL.FindIndex(x => x.Id == drone_id);
            if (index == -1)
            {
                throw new NotExistsException();
            }
            var droneToDisplay = ListDroneBL.Find(x => x.Id == drone_id);
            ParcelInTransfer parcel_to_add_drone = new ParcelInTransfer();


            if (droneToDisplay.IdOfParcelInTransfer != null)
            {
                var parcel = AccessToDataMethods.ReturnParcelList().ToList().Find(x => x.Id == droneToDisplay.IdOfParcelInTransfer);

                var senderCustomer = AccessToDataMethods.ReturnCustomerList().ToList().Find(x => x.Id == parcel.SenderId);
                var targetCustomer = AccessToDataMethods.ReturnCustomerList().ToList().Find(x => x.Id == parcel.TargetId);
                CustomerAtParcel SenderC = new CustomerAtParcel
                {
                    Id = senderCustomer.Id,
                    Name = senderCustomer.Name
                };
                CustomerAtParcel TargetC = new CustomerAtParcel
                {
                    Id = targetCustomer.Id,
                    Name = targetCustomer.Name
                };

                parcel_to_add_drone = new ParcelInTransfer
                {
                    Id = parcel.Id,
                    Weight = parcel.Weight.ToString(),
                    Priority = parcel.Priority.ToString(),
                    Sender = SenderC,
                    Reciever = TargetC,
                    DestLocation = new Location(targetCustomer.Longitude, targetCustomer.Latitude),
                    CollectionLocation = new Location(senderCustomer.Longitude, senderCustomer.Latitude),
                    TransportDistance = CalcDistanceBetweenTwoCoordinates(senderCustomer.Longitude, senderCustomer.Latitude, targetCustomer.Longitude, targetCustomer.Latitude)

                };

            }
            else
            {
                parcel_to_add_drone = null;
            }


            Drone BLdrone = new Drone
            {
                Id = droneToDisplay.Id,
                Model = droneToDisplay.Model,
                MaxWeight = droneToDisplay.Weight,
                Battery = droneToDisplay.Battery,
                CurrentLocation = droneToDisplay.CurrentLocation,
                Status = droneToDisplay.Status,
                Parcel = parcel_to_add_drone
            };

            return BLdrone;



        }
        public Customer DisplayCustomer(int customer_id)
        {
            int index = AccessToDataMethods.ReturnCustomerList().ToList().FindIndex(x => x.Id == customer_id);
            if (index == -1)
            {
                throw new NotExistsException();
            }
            var customer = AccessToDataMethods.ReturnCustomerList().ToList().Find(x => x.Id == customer_id);
            var senderIDparcels = AccessToDataMethods.ReturnParcelList().Where(x => x.SenderId == customer_id);
            var targetIDparcels = AccessToDataMethods.ReturnParcelList().Where(x => x.TargetId == customer_id);
            List<ParcelAtCustomer> parcelToSend = new List<ParcelAtCustomer>();
            List<ParcelAtCustomer> parcelToget = new List<ParcelAtCustomer>();

            foreach (var parcelSender in senderIDparcels) //create list of parcels that the customer should send
            {
                var name = AccessToDataMethods.ReturnCustomerList().ToList().Find(x => x.Id == parcelSender.TargetId).Name;
                CustomerAtParcel ToADD = new CustomerAtParcel();
                ToADD.Id = parcelSender.TargetId;
                ToADD.Name = name;
                parcelToSend.Add(new ParcelAtCustomer
                {

                    Id = parcelSender.Id,
                    Priority = parcelSender.Priority.ToString(),
                    Status = parcelStatus(parcelSender),
                    Weight = parcelSender.Weight.ToString(),
                    DestOrSrc = ToADD,

                });
            }

            foreach (var parcelTarget in targetIDparcels)// create list of parcels that the customer should get
            {
                var name = AccessToDataMethods.ReturnCustomerList().ToList().Find(x => x.Id == parcelTarget.SenderId).Name;
                CustomerAtParcel ToADD = new CustomerAtParcel();
                ToADD.Id = parcelTarget.TargetId;
                ToADD.Name = name;
                parcelToSend.Add(new ParcelAtCustomer
                {

                    Id = parcelTarget.Id,
                    Priority = parcelTarget.Priority.ToString(),
                    Status = parcelStatus(parcelTarget),
                    Weight = parcelTarget.Weight.ToString(),
                    DestOrSrc = ToADD,

                });
            }

            Customer customerToDisplay = new Customer
            {
                Id = customer.Id,
                location = new Location(customer.Longitude, customer.Latitude),
                Name = customer.Name,
                FromCustomer = parcelToSend,
                ToCustomer = parcelToget,
                PhoneNumber = int.Parse(customer.Phone)

            };

            return customerToDisplay;

        }
        public Parcel DisplayParcel(int parcel_id)
        {
            int index = AccessToDataMethods.ReturnParcelList().ToList().FindIndex(x => x.Id == parcel_id);
            if (index == -1)
            {
                throw new NotExistsException();
            }

            var parcelDisplay = AccessToDataMethods.ReturnParcelList().ToList().Find(x => x.Id == parcel_id);//the parcel we want to display


            //insert the customers of the entity to the relevent bl entity
            var customerSender = AccessToDataMethods.ReturnCustomerList().ToList().Find(x => x.Id == parcelDisplay.SenderId);
            var customerTarget = AccessToDataMethods.ReturnCustomerList().ToList().Find(x => x.Id == parcelDisplay.TargetId);
            CustomerAtParcel sender = new CustomerAtParcel { Id = customerSender.Id, Name = customerSender.Name };
            CustomerAtParcel target = new CustomerAtParcel { Id = customerTarget.Id, Name = customerTarget.Name };

            //insert the drone id to a bl entity
            var drone = ListDroneBL.Find(x => x.Id == parcelDisplay.DroneId);
            DroneAtParcel droneAt = new DroneAtParcel { Id = drone.Id, Battary = drone.Battery, CurrentLocation = drone.CurrentLocation };


            Parcel parcelTOreturn = new Parcel
            {
                Id = parcelDisplay.Id,
                Priority = parcelDisplay.Priority.ToString(),
                Weight = parcelDisplay.Weight.ToString(),
                sender = sender,
                target = target,
                DroneParcel = droneAt,
                TimeOfCreation = parcelDisplay.CreationTime,
                PairTime = parcelDisplay.ParingTime,
                CollectTime = parcelDisplay.PickedUp,
                DeliveryTime = parcelDisplay.ArrivedTime

            };


            return parcelTOreturn;

        }

        public IEnumerable<BaseStationToList> GetBaseStationToLists()
        {

            List<BaseStationToList> BaseStation = new List<BaseStationToList>();


            foreach (var station in AccessToDataMethods.ReturnStationList().ToList())
            {
                int counter = AccessToDataMethods.ReturnDroneChargeList().Count(x => x.StationId == station.Id);//count the occupied slots in the station
                BaseStation.Add(new BaseStationToList
                {
                    Id = station.Id,
                    Name = station.Name.ToString(),
                    NumOfAvailableChargingSlots = station.ChargeSlots - counter,//the total slots - the anount of drones in the station
                    NumOfUnavailableChargingSlots = counter
                });

            }

            return BaseStation;

        }
        public IEnumerable<DroneToList> GetDroneToLists()
        {

            return ListDroneBL;

        }
        public IEnumerable<CustomerToList> GetCustomerToLists()
        {
            List<CustomerToList> customerToLists = new List<CustomerToList>();


            foreach (var customer in AccessToDataMethods.ReturnCustomerList().ToList())
            {


                var sentAndArrived = AccessToDataMethods.ReturnParcelList().ToList().Where(x => x.SenderId == customer.Id).Where(x => x.ArrivedTime != null);
                var sentAndNotArrived = AccessToDataMethods.ReturnParcelList().ToList().Where(x => x.SenderId == customer.Id).Where(x => x.PickedUp != null).Where(x => x.ArrivedTime == null);
                var arrivedToCustomers = AccessToDataMethods.ReturnParcelList().ToList().Where(x => x.TargetId == customer.Id).Where(x => x.ArrivedTime != null);
                var OnTheWayTOcustomers = AccessToDataMethods.ReturnParcelList().ToList().Where(x => x.TargetId == customer.Id).Where(x => x.PickedUp != null);

                customerToLists.Add(new CustomerToList
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    PhoneNumber = int.Parse(customer.Phone),
                    NumOfParcelsThatSentAndArrived = sentAndArrived.Count(),
                    NumOfParcelsThatSentAndNotArrived = sentAndNotArrived.Count(),
                    NumOfArrivedParcels = arrivedToCustomers.Count(),
                    NumOfParcelsOnTheWay = OnTheWayTOcustomers.Count()

                });




            }
            return customerToLists;


        }
        public IEnumerable<ParcelToList> GetParcelToLists()
        {
            List<ParcelToList> myList = new();
            foreach (var Item in AccessToDataMethods.ReturnParcelList().ToList())
            {

                var find_SenderCustomer_Name = AccessToDataMethods.ReturnCustomerList().ToList().Find(x => x.Id == Item.SenderId);
                var find_TargetCustomer_Name = AccessToDataMethods.ReturnCustomerList().ToList().Find(x => x.Id == Item.TargetId);
                myList.Add(new ParcelToList
                {
                    Id = Item.Id,
                    Weight = Item.Weight.ToString(),
                    Status = parcelStatus(Item),
                    Priority = Item.Priority.ToString(),

                    SenderName = find_SenderCustomer_Name.Name,
                    ReceiverName = find_TargetCustomer_Name.Name
                });
            }

            return myList;
        }
        public IEnumerable<ParcelToList> GetNotPairedParcels()
        {
            List<ParcelToList> myNotPairedList = new();

            foreach (var Item in AccessToDataMethods.ReturnParcelList().ToList())
            {
                var find_SenderCustomer_Name = AccessToDataMethods.ReturnCustomerList().ToList().Find(x => x.Id == Item.SenderId);
                var find_TargetCustomer_Name = AccessToDataMethods.ReturnCustomerList().ToList().Find(x => x.Id == Item.TargetId);

                if (Item.DroneId == null && Item.ParingTime == null)
                {
                    myNotPairedList.Add(new ParcelToList
                    {
                        Id = Item.Id,
                        Status = parcelStatus(Item),
                        Weight = Item.Weight.ToString(),
                        Priority = Item.Priority.ToString(),


                        SenderName = find_SenderCustomer_Name.Name,
                        ReceiverName = find_TargetCustomer_Name.Name

                    });
                }
            }

            return myNotPairedList;
        }






    }
}
