using MediatR;
using Tibia.Ciclopedia.Application.BaseOutput;
using Tibia.Ciclopedia.Domain.ValueObjects;
using Tibia.Ciclopedia.Domain.ValueObjects.Enums;

namespace Tibia.Ciclopedia.Application.UseCases.CreateItem
{
    public class CreateItemInput : IRequest<Output<Guid>>
    {
        public string Name { get; set; }

        public ItemType Type { get; set; }

        public Vocations Vocations { get; set; }

        public int LevelRequired { get; set; }

        public SlotsInfo Slots { get; set; }

        public double Price { get; set; }

        public string Image {  get; set; }
    }

}
