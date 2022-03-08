#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Models;
using WSocialMedia.Areas.Identity.Data;
using WSocialMedia.Data;
using WSocialMedia.Models;

namespace WSocialMedia.Controllers
{
    public class SocialMediaAppController : Controller
    {
        private readonly WSocialMediaContext _context;
        private readonly UserManager<WSocialMediaUser> _userManager;

        public SocialMediaAppController(WSocialMediaContext context, UserManager<WSocialMediaUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: SocialMediaApp
        public async Task<IActionResult> Index()
        {
            var Data = (from post in _context.Posts
                        join user in _context.Users on post.User equals user
                        where post.Hide == false
                        orderby post.PostDate descending
                        select new HomeViewModel
                        {
                            postId = post.Id,
                            UserName = user.UserName,
                            PostContent = post.PostContent,
                            PostDate = post.PostDate,
                            Likes = post.Likes,
                            Comments = post.Comments
                        }).Take(10).ToList();
            
            return View(Data);
        }

        // POST: SocialMediaApp/Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Post(Post post)
        {
            if (!post.PostContent.Equals(null))
            {
                var user = await _userManager.GetUserAsync(User);
                var NewPost = new Post();

                NewPost.Id = Guid.NewGuid().ToString();
                NewPost.PostContent = post.PostContent;
                NewPost.PostDate = DateTime.Now;
                NewPost.User  = user;
                

                _context.Add(NewPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        // Post: SocialMediaApp/Like
        [HttpPost]
        public async Task<IActionResult> Like(string SMdpost_id)
        {

            //Check Post Exist
            var user = await _userManager.GetUserAsync(User);

            if (!_context.Posts.Any(post=> post.Id == SMdpost_id)) {
                return RedirectToAction(nameof(Index)); 
            }
            
            //IF Liked Before Do-Unlike
            
            if (_context.Likes.Any(like=>like.PostId == SMdpost_id && like.UserId == user.Id))
            {
                var Deletedlike = _context.Likes.FirstOrDefault(like => like.PostId == SMdpost_id && like.UserId == user.Id);
                _context.Likes.Remove(Deletedlike);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            Like NewLike = new Like()
            {
                likeID = Guid.NewGuid().ToString(),
                PostId = SMdpost_id,
                UserId = user.Id
            };
            _context.Likes.Add(NewLike);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
     }

        // Post: SocialMediaApp/Comment
        [HttpPost]
        public async Task<IActionResult> Comment(string SMdpost_id,string Comment_txt)
        {
            //Check Post Exist
            var user = await _userManager.GetUserAsync(User);

            if (!_context.Posts.Any(post => post.Id == SMdpost_id))
            {
                return RedirectToAction(nameof(Index));
            }
            Comment NewComment = new Comment() { 
                commentID = Guid.NewGuid().ToString(),
                PostId = SMdpost_id,
                CommentContent = Comment_txt,
                CommentUserName = user.Email,
                UserId = user.Id
            };           

            _context.Comments.Add(NewComment);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }



        //Get: SocialMediaApp/Profile
        [HttpGet]
        public async Task<ActionResult> Profile() {
            
            var user = await _userManager.GetUserAsync(User);
            var model = _context.Informations.Any(info => info.UserId == user.Id) ? _context.Informations.Single(info => info.UserId == user.Id) : new Information();
            return View(model);
        }

        //Post: SocialMediaApp/Profile

        [HttpPost]
        public async Task<IActionResult> Profile(Information information)
        {

            var user = await _userManager.GetUserAsync(User);
            //Add External Fields
            information.Id = Guid.NewGuid().ToString();
            information.UserId = user.Id;
            information.ProfilePictureUrl = "";
           
            if (_context.Informations.Any(info => info.UserId == user.Id))
            {
                _context.Informations.Update(information);
                ViewData["AlertType"] = "info";
                ViewData["Message"] = "Successfully Updated";
            }
            else
            {
                _context.Informations.Add(information);
                ViewData["AlertType"] = "success";
                ViewData["Message"] = "Successfully Created";
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
