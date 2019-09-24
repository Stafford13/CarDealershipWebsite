using GuildCars.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    interface IAccountRepository
   {
    //    IEnumerable<FeaturedItem> GetFeatured(string userId);
    //    IEnumerable<ContactRequestItem> GetContacts(string userId);
    //    IEnumerable<CarItem> GetCars(string userId);
        void AddFavorite(string userId, int listingId);
        void RemoveFavorite(string userId, int listingId);
        void AddContact(string userId, int listingId);
        void RemoveContact(string userId, int listingId);
        bool IsFeatured(string userId, int listingId);
        bool IsContact(string userId, int listingId);
    }
}
