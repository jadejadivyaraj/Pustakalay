using System;
using Microsoft.Practices.Prism.Commands;
using Pustakalay.Data;
using Pustakalay.Infrastructure;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Windows.Data;


namespace Pustakalay.MembersModule.ViewModels
{
	class MembersViewModel : ViewModelBase, IMembersViewModel
	{
		private readonly PustakalayModelContext _ctx = new PustakalayModelContext();

		private ObservableCollection<Member> _membersInternal;

		private CollectionView _members; 

		public ObservableCollection<Member> MembersInternal
		{
			get { return _membersInternal?? new ObservableCollection<Member>(); }
			//set { _membersInternal = value; }
		}

		public CollectionView Members
		{
			get { return _members ?? (_members = new CollectionView(_membersInternal)); }
			//set { _members = value; }
		}
		public DelegateCommand AddCommand { get; set; }

		public DelegateCommand SaveCommand { get; set; }

		public DelegateCommand DeleteCommand { get; set; }

		public MembersViewModel()
		{
			AddCommand = new DelegateCommand(OnAdd, CanAdd);
			SaveCommand = new DelegateCommand(OnSave, CanSave);
			DeleteCommand = new DelegateCommand(OnDelete,CanDelete);
			_ctx.Members.Load();
			_membersInternal = _ctx.Members.Local;
			//var aMember = new Member()
			//    {
			//        Id = Guid.NewGuid(),
			//        FirstName = "Divyaraj",
			//        LastName = "Jadeja",
			//        Email = "jadejadivyaraj@gmail.com",
			//        Phone = "123456789",
			//        Address = new Address() { AddLine1 = "add1",AddLine2 = "add2", City = "Bangalore", Pincode = "123"}
			//    };
			//_ctx.Members.Add(aMember);
			//_ctx.SaveChanges();
			
		}

		private bool CanDelete()
		{
			return true;
		}

		private void OnDelete()
		{
			var aMember = _members.CurrentItem as Member;
			if(aMember!=null)
				_ctx.Members.Remove(aMember);
		}

		private bool CanSave()
		{
			return true;
		}

		private void OnSave()
		{
			_ctx.SaveChanges();
		}

		private void OnAdd()
		{
			var aMember = new Member
				{
				Id = Guid.NewGuid(),
				//FirstName = "Divyaraj4",
				//LastName = "Jadeja4",
				//Email = "jadejadivyaraj@gmail.com4",
				//Phone = "1234567894",
				Address = new Address { AddLine1 = "add1", AddLine2 = "add2", City = "Bangalore", Pincode = "123" }
					
			};
			_ctx.Members.Add(aMember);
			Members.MoveCurrentTo(aMember);
		}

		private bool CanAdd()
		{
			return true;
		}

	}
}
