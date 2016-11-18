using System;

namespace UsersDatabase
{
    using System.Collections.Generic;
    using System.Data.Entity.Validation;
    using System.Linq;
    using Models;

    class Program
    {
        static void Main()
        {
            UsersContext context = new UsersContext();

            //RecievingTags(context);
        }

        private static void RecievingTags(UsersContext context)
        {
            string parameterInput = Console.ReadLine();

            Tag tag = new Tag()
            {
                TagLabel = parameterInput
            };

            try
            {
                context.Tags.Add(tag);
                context.SaveChanges();
            }
            catch (DbEntityValidationException dbex)
            {
                tag.TagLabel = TagTransformer.Transform(tag.TagLabel);
                context.SaveChanges();
            }
        }
    }
}
