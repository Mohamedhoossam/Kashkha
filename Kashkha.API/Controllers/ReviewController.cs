using Kashkha.BL;
using Kashkha.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kashkha.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReviewController : ControllerBase
	{
		private readonly IReviewManager _reviewManager;

		public ReviewController(IReviewManager reviewManager)
        {
			_reviewManager = reviewManager;
		}

		[HttpPost]
		public ActionResult PostReview([FromForm] AddReviewDto reviewDto)
		{
			if (reviewDto is null)
			{
				return BadRequest("The comment must not be empty");
			}
			_reviewManager.Add(new Review()
			{
				CustomerComment = reviewDto.CustomerComment,
				CustomerId = reviewDto.CustomerId,
				CustomerName = reviewDto.CustomerName,
				ProductId = reviewDto.ProductId,
			}) ;
			return Ok(reviewDto);
		}

		[HttpDelete("{id:int}")]
		public ActionResult DeleteReview([FromRoute] int id)
		{

			var review = _reviewManager.GetById(id);
			if (review is null)
			{
				return NotFound("No review found");
			}
			_reviewManager.Delete(review);
			return NoContent();
		}

		[HttpPatch]
		public ActionResult UpdateReview([FromForm] ReviewUpdateDto reviewDto)
		{
			if (reviewDto is null)
			{
				return NotFound("No review found");
			}
			_reviewManager.Update(reviewDto);
			return NoContent();
		}


	}
}
