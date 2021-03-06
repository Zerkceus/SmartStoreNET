using System;
using System.Collections.Generic;
using SmartStore.Core;
using SmartStore.Core.Domain.Customers;
using SmartStore.Core.Domain.Dashboard;
using SmartStore.Core.Domain.Orders;
using SmartStore.Core.Domain.Payments;
using SmartStore.Core.Domain.Shipping;
using static SmartStore.Services.Customers.CustomerReportService;

namespace SmartStore.Services.Customers
{
    /// <summary>
    /// Customer report service interface
    /// </summary>
    public partial interface ICustomerReportService
    {
        /// <summary>
        /// Get best customers
        /// </summary>
        /// <param name="startTime">Order start time; null to load all</param>
        /// <param name="endTime">Order end time; null to load all</param>
        /// <param name="os">Order status; null to load all records</param>
        /// <param name="ps">Order payment status; null to load all records</param>
        /// <param name="ss">Order shippment status; null to load all records</param>
        /// <param name="orderBy">1 - order by order total, 2 - order by number of orders</param>
        /// <returns>Report</returns>
        IList<TopCustomerReportLine> GetTopCustomersReport(DateTime? startTime, DateTime? endTime, OrderStatus? os, PaymentStatus? ps, ShippingStatus? ss, int orderBy, int count);
        
        /// <summary>
        /// Gets a report of customers registered in the last days
        /// </summary>
        /// <param name="days">Customers registered in the last days</param>
        /// <returns>Number of registered customers</returns>
        int GetRegisteredCustomersReport(int days);

        /// <summary>
        /// Get customers registrations sorted by date
        /// </summary>
        /// <returns>Customer registrations</returns>
        List<RegistredCustomersDate> GetRegisteredCustomersDate();

        /// <summary>
        /// Get customer chart report
        /// </summary>
        /// <param name="allCustomers">List of customers</param>
        /// <param name="state">Time period</param>
        /// <returns>Customers chart report</returns>
        DashboardChartReportLine GetCustomersDashboardReport(IPagedList<Customer> allCustomers, PeriodState state);
    }
}