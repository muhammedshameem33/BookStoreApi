using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApi
{
    // --------------------------------------------------------------------------------------------------------------------
    // <copyright file="MappingProfiles.cs" company="Bridgelabz">
    //   Copyright © 2020 Company="BridgeLabz"
    // </copyright>
    // <creator name="Shameem"/>
    // --------------------------------------------------------------------------------------------------------------------

    namespace FundooApi
    {
        using System;
        using System.Collections.Generic;
        using System.Text;
        using AutoMapper;
        using BookStoreModelLayer.Book;

        /// <summary>
        /// Code for mapping
        /// </summary>
        /// <seealso cref="AutoMapper.Profile" />
        public class MappingProfiles : Profile
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="MappingProfiles"/> class.
            /// </summary>
            public MappingProfiles()
            {
                this.CreateMap<AddBookModel, Book>();
            }
        }
    }

}
