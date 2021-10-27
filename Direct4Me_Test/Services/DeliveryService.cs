using System;
using System.Collections.Generic;
using System.Linq;
using Direct4Me_Test.Entities;
using Direct4Me_Test.Helpers;
using Direct4Me_Test.Models.DeliveryServiceModel;
using Microsoft.EntityFrameworkCore;

namespace Direct4Me_Test.Services
{
    public interface IDelivery_Service
    {
        IEnumerable<DeliveryService> GetAll();

        IEnumerable<DeliveryServiceCountModel> GetDeliveryCount();
       
        DeliveryService GetById(int id);
        DeliveryService Create(DeliveryService delivery);
        void Update(DeliveryService delivery);
        void Delete(int id);
    }

    public class Delivery_Service : IDelivery_Service
    {
        private DataContext _context;

        public Delivery_Service(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<DeliveryService> GetAll()
        {
            return _context.DeliveryServices;
        }

        public IEnumerable<DeliveryServiceCountModel> GetDeliveryCount()
        {

            var test = _context.DeliveryServices;
            var result = _context.DeliveryServices.GroupBy(x => x.Code).Select( x => new DeliveryServiceCountModel { 
            Title = x.Key,
            Count = _context.DeliveryServices.Include(b => b.Articles).Count()
            });

            return result;
        }

        public DeliveryService GetById(int id)
        {
            return _context.DeliveryServices.Find(id);
        }

        public DeliveryService Create(DeliveryService delivery)
        {
            // validation
            if (string.IsNullOrWhiteSpace(delivery.Title))
                throw new AppException("Title is required");

            if (string.IsNullOrWhiteSpace(delivery.Code))
                throw new AppException("Code is required");

            _context.DeliveryServices.Add(delivery);
            _context.SaveChanges();

            return delivery;
        }

        public void Update(DeliveryService deliveryParam)
        {
            var delivery = _context.DeliveryServices.Find(deliveryParam.Id);

            if (delivery == null)
                throw new AppException("Delivery not found");

            if (string.IsNullOrWhiteSpace(delivery.Title))
                throw new AppException("Title is required");

            if (string.IsNullOrWhiteSpace(delivery.Code))
                throw new AppException("Code is required");


            delivery.Title = deliveryParam.Title;
            delivery.Code = deliveryParam.Code;

          
            _context.DeliveryServices.Update(delivery);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var delivery = _context.DeliveryServices.Find(id);
            if (delivery != null)
            {
                _context.DeliveryServices.Remove(delivery);
                _context.SaveChanges();
            }
        }
    }
}