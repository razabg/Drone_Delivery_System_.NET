using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL.BO
{
    public partial class BLObject
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
            IEnumerable<IDAL.DO.DroneINCharge> DroneINChargeListDal = AccessToDataMethods.ReturnDroneChargeList().Where(x => x.StationId == DLstationToDisplay.Id);
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

            foreach (var parcelSender in senderIDparcels)
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
           
                }) ;


            }

        }



    }
}
