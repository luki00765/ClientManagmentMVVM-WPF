using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ClientManagment.Command;
using ClientManagment.Model;

namespace ClientManagment.ViewModel
{
	public class MainWindowViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private ObservableCollection<Client> _clients;
		public ObservableCollection<Client> Clients
		{
			get { return _clients; }
			set
			{
				if (_clients != value)
				{
					_clients = value;
					OnPropertyChanged(() => Clients);
				}
			}
		}

		private void OnPropertyChanged<T>(Expression<Func<T>> propertySelector)
		{
			MemberExpression memberExpression = (MemberExpression)propertySelector.Body;
			string propertyName = memberExpression.Member.Name;

			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}

		// konstruktor
		public MainWindowViewModel()
		{
			Clients = new ObservableCollection<Client>(Repository.GetClients());
			AddClientCommand = new DelegateCommand(AddClientAction);
			DeleteClientCommand = new DelegateCommand(DeleteClientAction);
		}

		public ICommand AddClientCommand { get; private set; }

		private void AddClientAction(object obj)
		{
			Clients.Add(new Client());
		}

		public ICommand DeleteClientCommand { get; private set; }

		private void DeleteClientAction(object obj)
		{
			Clients.Remove(_selected);
		}

		// zaznaczony klient i czy szczegóły są widoczne - dla textBoxa
		private Client _selected;
		private bool _isDetailsShown;

		public Client SelectedClient
		{
			get { return _selected; }
			set
			{
				// zmienia godność klienta
				if (_selected != value)
				{
					_selected = value;
					IsDetailsShown = SelectedClient != null;
					OnPropertyChanged(() => SelectedClient);
				}
			}
		}

		public bool IsDetailsShown
		{
			get { return _isDetailsShown; }
			set
			{
				if (_isDetailsShown != value)
				{
					_isDetailsShown = value;
					OnPropertyChanged(() => IsDetailsShown);
				}
			}
		}

	}
}
