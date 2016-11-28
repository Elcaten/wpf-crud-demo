using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Lineyschikov.WpfAssignment.Desktop.Commands;
using Lineyschikov.WpfAssignment.Desktop.Models;
using CustomersService = Lineyschikov.WpfAssignment.Desktop.Services.CustomersService;
using OrdersService = Lineyschikov.WpfAssignment.Desktop.Services.OrdersService;

namespace Lineyschikov.WpfAssignment.Desktop.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
    {
        private readonly CustomersService _customersService;
        private readonly OrdersService _ordersService;
        private bool _customerOperationInProgress;
        private bool _addingOrderOperationInProgress;
        private bool _databaseOperationInProgress;
        private Customer _selectedCustomer;
        private Order _selectedOrder;
        private ObservableCollection<Order> _orders;

        public ObservableCollection<Customer> Customers { get; set; }
        public ObservableCollection<Order> Orders
        {
            get { return _orders; }
            set { SetAndNotify(ref _orders, value); }
        }
        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                SetAndNotify(ref _selectedCustomer, value);
                Orders = value == null || value.Orders == null 
                    ? new ObservableCollection<Order>() 
                    : new ObservableCollection<Order>(value.Orders);
                Orders.CollectionChanged += OnOrdersChange;
				OrderOperationInProgress = false;
            }
        }
        public Order SelectedOrder
        {
            get { return _selectedOrder; }
            set { SetAndNotify(ref _selectedOrder, value); }
        }
        public int SelectedOrderIndex { get; set; }
        public bool CustomerOperationInProgress
        {
            get { return _customerOperationInProgress; }
            set { SetAndNotify(ref _customerOperationInProgress, value); }
        }
        public bool OrderOperationInProgress
        {
            get { return _addingOrderOperationInProgress; }
            set { SetAndNotify(ref _addingOrderOperationInProgress, value); }
        }

        public bool DatabaseOperationInProgress
        {
            get { return _databaseOperationInProgress; }
            set { SetAndNotify(ref _databaseOperationInProgress, value); }
        }

        public ICommand AddCustomerCommand { get; set; }
        public ICommand DeleteCustomerCommand { get; set; }
        public ICommand ConfirmCustomerOperataionCommand { get; set; }
        public ICommand CancelCustomerOperataionCommand { get; set; }

        public ICommand AddOrderCommand { get; set; }
        public ICommand EditOrderCommand { get; set; }
        public ICommand DeleteOrderCommand { get; set; }
        public ICommand ConfirmOrderOperataionCommand { get; set; }
        public ICommand CancelOrderOperataionCommand { get; set; }

        public MainWindowViewModel()
        {
        }

        public MainWindowViewModel(CustomersService customersService, OrdersService ordersService)
        {
            if (customersService == null) throw new ArgumentException("customersService");
            if (ordersService == null) throw new ArgumentException("ordersService");
            _customersService = customersService;
            _ordersService = ordersService;

            Customers = new ObservableCollection<Customer>(_customersService.GetAll().Result);
            Orders = new ObservableCollection<Order>();

            AddCustomerCommand = new SimpleCommand(() =>
            {
                CustomerOperationInProgress = true;
                OrderOperationInProgress = false;
                SelectedCustomer = new Customer();
            });
            DeleteCustomerCommand = new SimpleCommand(() =>
            {
                if (SelectedCustomer == null) return;
                Customers.Remove(SelectedCustomer);
            });
            CancelCustomerOperataionCommand = new SimpleCommand(() => CustomerOperationInProgress = false);
            ConfirmCustomerOperataionCommand = new SimpleCommand(() =>
            {
                Customers.Add(SelectedCustomer);
                CustomerOperationInProgress = false;
            });

            AddOrderCommand = new SimpleCommand(() =>
            {
                OrderOperationInProgress = true;
                CustomerOperationInProgress = false;
                SelectedOrder = new Order {CustomerId = SelectedCustomer.Id};
            });
            EditOrderCommand = new SimpleCommand(() =>
            {
                if (SelectedOrder == null) return;
                OrderOperationInProgress = true;
            });
            DeleteOrderCommand = new SimpleCommand(() =>
            {
                if (SelectedOrder == null) return;
                Orders.Remove(SelectedOrder);
            });
            CancelOrderOperataionCommand = new SimpleCommand(() =>
            {
                OrderOperationInProgress = false;
                SelectedOrder = null;
            });
            ConfirmOrderOperataionCommand = new SimpleCommand<string>(description =>
            {
                OrderOperationInProgress = false;
                SelectedOrder.Description = description;
                if (SelectedOrder.Id == 0)
                    Orders.Add(SelectedOrder);
                else
                {             
                    Orders[SelectedOrderIndex] = SelectedOrder;
                }
            });

            Customers.CollectionChanged += OnCustomersChange;
        }

        private async void OnCustomersChange(object sender, NotifyCollectionChangedEventArgs e)
        {
            DatabaseOperationInProgress = true;
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                var customer = GetFirst<Customer>(e.NewItems);
                await _customersService.Create(customer);
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                var customer = GetFirst<Customer>(e.OldItems);
                await _customersService.Delete(customer.Id);
            }
            DatabaseOperationInProgress = false;
        }

        private async void OnOrdersChange(object sender, NotifyCollectionChangedEventArgs e)
        {
            DatabaseOperationInProgress = true;
            var order = e.Action == NotifyCollectionChangedAction.Remove
                ? GetFirst<Order>(e.OldItems)
                : GetFirst<Order>(e.NewItems);
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                var orderId = await _ordersService.Create(order);
                Orders[SelectedOrderIndex].Id = orderId;
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                await _ordersService.Delete(order.Id);
            }
            else if (e.Action == NotifyCollectionChangedAction.Replace)
            {
                await _ordersService.Update(order);
            }
            DatabaseOperationInProgress = false;
        }

        private static T GetFirst<T>(IList collection)
        {
            return collection.Cast<T>().First();
        }
    }
}