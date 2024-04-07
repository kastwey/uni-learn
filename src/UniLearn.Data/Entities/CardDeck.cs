using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UniLearn.Data.Enums;

namespace UniLearn.Data.Entities;

public class CardDeck
{

	public Guid CardDeckId { get; set; }

	public required string Name { get; set; }

	public string? Description { get; set; }

	public required ICollection<Card> Cards { get; set; }

	public DateTime CreatedDate { get; set; }

	public DateTime LastModifiedDate { get; set; }
}
