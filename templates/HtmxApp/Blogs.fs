namespace HtmxApp

open Fun.Blazor
open Fun.Htmx

type Blogs =
    static member Partial(db: DbContext) = task {
        let! blogs = db.GetBlogs()
        return div {
            childContent [
                for blog in blogs do
                    div {
                        class' "rounded-md bg-slate-300 hover:bg-slate-600 hover:text-white hover:shadow-md mb-3 p-3 cursor-pointer"
                        h2 { blog.Title }
                        p {
                            class' "text-sm"
                            blog.CreatedAt.ToString("yyy-MM-dd HH:mm:ss")
                        }
                    }
            ]
        }
    }

    static member Page() =
        Layout.Create (
            section {
                div {
                    class' "text-center mt-5 text-slate-600"
                    hxGet "/blogs"
                    hxSwap_innerHTML
                    hxTarget "#blogs"
                    hxIndicator "#blogs_loader"
                    hxTrigger' (hxEvt.load, delayMs = 1000)
                    "Below is my demo blogs"
                }
                div {
                    id "blogs_loader"
                    class' "htmx-indicator text-purple-800 text-center"
                    "Loading blogs ..."
                }
                div { id "blogs" }
            }
        )