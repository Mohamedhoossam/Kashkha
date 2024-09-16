using Kashkha.BL;
using Kashkha.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Kashkha.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]

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
			var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
			var usernName = User.FindFirst(ClaimTypes.Name)?.Value;

			if (reviewDto is null)
			{
				return BadRequest("The comment must not be empty");
			}
			_reviewManager.Add(new Review()
			{
				UserComment = reviewDto.UserComment,
				UserId = userId,
				UserName = usernName,
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

		[HttpPut]
		public ActionResult UpdateReview([FromForm] ReviewUpdateDto reviewDto)
		{
			if (reviewDto is null)
			{
				return NotFound("No review found");
			}

		   var result=	_reviewManager.Update(reviewDto);
			if (result is null)
				return NotFound();

			return NoContent();
		}


	}
}
