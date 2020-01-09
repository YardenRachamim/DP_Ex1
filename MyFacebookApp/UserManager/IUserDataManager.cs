using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyFacebookApp
{
    interface IUserDataManager
    {
        FacebookObjectCollection<User> Friends { get; }

        FacebookObjectCollection<Album> Albums { get; }

        FacebookObjectCollection<Post> Posts { get; }

        FacebookObjectCollection<Page> LikedPages { get; }

        City Hometown { get; }

        User.eRelationshipStatus? RelationshipStatus { get; }

        string PictureNormalURL { get; }

        string FirstName { get; }

        string LastName { get; }

        string Birthday { get; }

        string Religion { get; }

        double? TimeZone { get; }

        string Id { get; }

        string Name { get; }

        User LoggedInUser { get; set; }

        void RestartLoggedInUser();
    }
}
