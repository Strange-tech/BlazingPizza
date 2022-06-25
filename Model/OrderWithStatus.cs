using System;
using System.Collections.Generic;
using CliDll;

namespace BlazingPizza
{
    /// <summary>
    /// 附带状态的订单
    /// </summary>
    public class OrderWithStatus
    {
        public readonly static TimeSpan PreparationDuration = TimeSpan.FromSeconds(10);
        public readonly static TimeSpan DeliveryDuration = TimeSpan.FromMinutes(1);
        public readonly static State OrderCurrentSate = new State();
        public Order Order { get; set; }

        public string StatusText { get; set; }

        public bool IsDelivered => StatusText == "Delivered";

        public static OrderWithStatus FromOrder(Order order)
        {
            var dispatchTime = order.CreatedTime.Add(PreparationDuration);

            string statusText = OrderCurrentSate.GetState(dispatchTime, DeliveryDuration);

            return new OrderWithStatus
            {
                Order = order,
                StatusText = statusText
            };
        }


    }
}
