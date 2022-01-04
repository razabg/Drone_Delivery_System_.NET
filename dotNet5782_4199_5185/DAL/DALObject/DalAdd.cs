using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;


namespace DAL
{
    /// <summary>
    /// method that add new station to stations list
    /// </summary>
    internal sealed partial class DALobject
    {
        #region Add methods

        /// <summary>
        /// Get a Custemer type and add put him in the customer list.
        /// </summary>
        /// <param name="CustomerToAdd"></param>
        public void AddCustomer(Customer CustomerToAdd)
        {
            if (DataSource.CustomersList.ToList().Exists(x => x.Id == CustomerToAdd.Id))
            {
                throw new AlreadyExistsException("the customer is alreay exists");
            }

            DataSource.CustomersList.Add(new Customer
            {
                Id = CustomerToAdd.Id,
                Name = CustomerToAdd.Name,
                Phone = CustomerToAdd.Phone,
                Longitude = CustomerToAdd.Longitude,
                Latitude = CustomerToAdd.Latitude,
            });
        }

        /// <summary>
        /// method that add new drone to drones list
        /// </summary>
        public void AddDrone(Drone drone_add)
        {
            if (DataSource.DronesList.ToList().Exists(x => x.Id == drone_add.Id))
            {
                throw new AlreadyExistsException("Already exists drone");
            }

            DataSource.DronesList.Add(new Drone()
            {
                Id = drone_add.Id,
                Model = drone_add.Model,
                MaxWeight = drone_add.MaxWeight,
            }); ;
        }
        /// <summary>
        /// Get a Parcel type and put him in the parcels list.
        /// </summary>
        /// <param name="parcel"></param>
        public void AddParcel(Parcel parcel)
        {
            if (DataSource.ParcelsList.ToList().Exists(x => x.Id == parcel.Id))
            {
                throw new AlreadyExistsException("the parcel is alreay exists");
            }
            DataSource.ParcelsList.Add(new Parcel
            {
                Id = DataSource.Config.RunIdParcel++,//CHECK RUN ID PARCEL
                SenderId = parcel.SenderId,
                TargetId = parcel.TargetId,
                Weight = parcel.Weight,
                Priority = parcel.Priority,
                DroneId = null,
                CreationTime = DateTime.Now,
                ParingTime = null,
                PickedUp = null,
                ArrivedTime = null,
            });

        }
        public void AddStation(Station tolist)
        {
           
            if (DataSource.StationsList.ToList().Exists(x=>x.Id==tolist.Id))
            {
                throw new AlreadyExistsException("the station is already exists");
            }

            DataSource.StationsList.Add(new Station()
            {
                Id = tolist.Id,
                Name = tolist.Name,
                Longitude = tolist.Longitude,
                Latitude = tolist.Latitude,
                ChargeSlots = tolist.ChargeSlots
            });
        }
        #endregion

    }

}
