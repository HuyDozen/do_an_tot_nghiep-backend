﻿using Ecommerce.Website.Application.Contacts;
using Ecommerce.Website.Database.Contacts;
using Ecommerce.Website.Database.Models;
using Ecommerce.Website.Database.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Website.Application.Services
{
    public class OrderService : BaseService<Order>, IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository) : base(orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public ListOrderDetailModel InsertOrder(OrderDetailModel detail)
        {
            return _orderRepository.InsertOrder(detail);
        }
    }
}
