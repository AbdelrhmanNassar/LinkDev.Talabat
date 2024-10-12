using LinkDev.Talabat.Core.Application.Abstraction;
using LinkDev.Talabat.Core.Domain.Comman;
using LinkDev.Talabat.Infrastrucutre.Infrastructure.Date;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Infrastructure.Peresistance.Interceptors
{
	public class CustomSaveChangesInterceptor :SaveChangesInterceptor
	{
		private readonly ILoggedInUserServices loggedInUserServices;

		public CustomSaveChangesInterceptor(ILoggedInUserServices loggedInUserServices )
        {
			this.loggedInUserServices = loggedInUserServices;
		}

		public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
		{
			updateEnitites(eventData.Context); 
			return base.SavingChanges(eventData, result);
		}
		public override ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
		{

			updateEnitites(eventData.Context);
			return base.SavedChangesAsync(eventData, result, cancellationToken);
		}


		private void updateEnitites(DbContext storeContext)//how dbcontext will work? the refernce has not these properites
		{
			
			if (storeContext is not null)
			{
				var utcNow = DateTime.UtcNow;
				foreach (var entry in storeContext.ChangeTracker.Entries<BaseAuditableEntitiy<int>>())//but here you determined it would be always int 
				{
					{
						if (entry is { State: EntityState.Added or EntityState.Modified })// i check if the sate is updated or added
																						  //set the adminstration feilds without using intetceptor
																						  //but the problem here i want an id of the admin not the add it
																						  //you can get it with a service(which get the id) by asking in ctor  
																						  //but in other places which use store context you don't need this service to get but you forced   
																						  //anyone use storecontext to get the id
						{
							if (entry.State == EntityState.Added)
							{
								entry.Entity.CreatedBy = loggedInUserServices.UserId;
								entry.Entity.CreatedOn = utcNow;
							}
							entry.Entity.LastModifiedBy = loggedInUserServices.UserId;
							entry.Entity.LastModifiedOn = utcNow;
						}


					}
				}
			}
			return;

		}
	}
}
