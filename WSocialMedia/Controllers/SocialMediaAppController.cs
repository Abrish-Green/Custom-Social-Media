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
            return View(post);
        }

        // Get: SocialMediaApp/Like
        [HttpGet]
        public async Task<IActionResult> Like(string postId)
        {
            //Get Post
            var user = await _userManager.GetUserAsync(User);
            var post = _context.Posts.SingleOrDefault(p => p.Id == postId);

            //Check if Liked
            if (post.Likes.Any(like => like.UsersId == user.Id))
            {
                //Post Liked
                //Remove like from list
                var tempLike = post.Likes.FirstOrDefault(like => like.UsersId == user.Id);
                _context.Posts.FirstOrDefault(p => p.Id == postId).Likes.Remove(tempLike);
            }
            else
            {
                //Post NOT liked
                //Add Like
                var NewLike = new Like()
                {
                    Id = Guid.NewGuid().ToString(),
                    UsersId = user.Id
                };
                _context.Posts.FirstOrDefault(p => p.Id == postId).Likes.Add(NewLike);
            }

            await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
     }








        // GET: SocialMediaApp/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: SocialMediaApp/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SocialMediaApp/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PostTitle,PostContent,PostDate,Hide,Catagory")] Post post)
        {
            if (ModelState.IsValid)
            {
                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        // GET: SocialMediaApp/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        // POST: SocialMediaApp/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,PostTitle,PostContent,PostDate,Hide,Catagory")] Post post)
        {
            if (id != post.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(post);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        // GET: SocialMediaApp/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: SocialMediaApp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var post = await _context.Posts.FindAsync(id);
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(string id)
        {
            return _context.Posts.Any(e => e.Id == id);
        }
    }
}
