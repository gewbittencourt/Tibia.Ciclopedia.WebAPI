using MediatR;
using System.Diagnostics;
using System.Xml.Linq;
using Tibia.Ciclopedia.Application.BaseOutput;
using Tibia.Ciclopedia.Domain.ValueObjects;
using Tibia.Ciclopedia.Domain.ValueObjects.Enums;
using static System.Net.Mime.MediaTypeNames;
using static System.Reflection.Metadata.BlobBuilder;

namespace Tibia.Ciclopedia.Application.UseCases.CreateItem
{
    public class CreateItemInput : IRequest<Output<Guid>>
    {
        public string Name { get; set; }

        public ItemType Type { get; set; }

        public Vocations Vocations { get; set; }

        public int LevelRequired { get; set; }

        public SlotsInfoItem Slots { get; set; }

        public double Price { get; set; }

        public string Image {  get; set; }


		public CreateItemInput()
		{
		}
	}



}
