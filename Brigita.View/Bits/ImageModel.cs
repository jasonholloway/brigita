using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brigita.View.Bits
{
    public class ImageModel
    {
        public string Title { get; set; }
        public string AltText { get; set; }
        public string Url { get; set; }
        public string FullSizeUrl { get; set; }
    }


    //URLs are *always* a matter for the presentation layer
    //in fact, in this, the lower reaches of the domain and the presentation are not layered, but cooperate
    //horizontally.

    //Within an MVC project, this is fine and dandy, as viewmodel- and url-generation all occur in the same
    //conglomerate project. But as soon as the viewmodel, and its concomitant services, are separated out, 
    //this comes to the fore: where does url-generation sit? Some services must be provided by the bottom
    //layer; not all are to be provided from above.

    //What would a URL-generation service therefore look like? It would fulfil an interface defined by the
    //ViewModel layer. That is, the ViewModel layer will not function without the presentation-implementation
    //layer offering certain resources.

    //The ViewModel layer doesn't need to bother itself with the content of the Location classes it receives
    //from below to package with its model classes and resend downwards. The View layer will know how to interpret
    //its own Locations

}
