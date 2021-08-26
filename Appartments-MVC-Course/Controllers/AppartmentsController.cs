using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web.Mvc;
using Appartments_MVC_Course.Dtos;
using Appartments_MVC_Course.Models;
using Appartments_MVC_Course.ViewModels;
using AutoMapper;

namespace Appartments_MVC_Course.Controllers
{
    public class AppartmentsController : Controller
    {
        //private List<Apartment> apartements = new List<Apartment>
        //{
        //    new Apartment(1, "1", "Tel-Aviv", "Shinkin", 32, "bla bla", 400,
        //        "https://pic.le-cdn.com/thumbs/520x390/04/1/properties/Property-dbe900000000047a00015d7e1009-75164123.jpg"),
        //    new Apartment(2, "1", "Haifa", "Ahuza", 23, "bla bla bla", 200,
        //        "data:image/jpeg;base64,/9j/4AAQSkZJRgABAQAAAQABAAD/2wCEAAoHCBUVFRgVFRUYGBIYGBgYGRgaFRgYGBgYGBgZGhgYGBocIS4lHB4rHxkYJjgmKy8xNTU1GiQ7QDs0Py40NTEBDAwMEA8QHBISGjQhISE0MTQxNDQxNDQ0NDQ0NDQ0MTExNDQ0NDQ0NDQxNDQ0NDQ0NDQ0NDQ0NDQ0NDE0NDQ0NP/AABEIALcBEwMBIgACEQEDEQH/xAAcAAABBQEBAQAAAAAAAAAAAAADAAECBAUGBwj/xABIEAACAQIEAgUIBQkHBAMBAAABAgADEQQSITEFQSJRYXGBBhMyUpGhscEUI0Jy0QczYnOCkrLS8BVTorPC4fEWJWOTNIOjF//EABgBAQEBAQEAAAAAAAAAAAAAAAABAgME/8QAHhEBAQEAAgMBAQEAAAAAAAAAAAERAiESEzFRQQP/2gAMAwEAAhEDEQA/AO4vFHIjTmGiiigSRyJDHYJaozLpUHPr7G/GPHRiDcSwZWGxJRijg5b+KnrHZNO3s5HkZPE4VKw6qg2PyPWJmYeq1MlHBAB/dvzHWJaNESVpC8kDIJRSAfW1j38pMGA8eNFAcSQkRJAwiYkhIAyQM0JCSEiDHBhUxJiQBk1MCYEmJAGSDQiYjyIMe8B40a85Lyl8qXWoMFgVFbHsNeaUF5vVOwIuNO0X3AIH8rvKsYXLRooa2OqWFOiuti17M9tl0Om5sdgCRneTPkoadQ4zGt57Hvrc6rR/RQbXG19hsOs3fJzycTCZqrv57GVLmpXbViTuqX1VfebdwGhXxBO0WgmJxUqWLbx1TmYULM/RFUkwI9o8KUUUUCjw7jFCvfzb3ZfSRgVdD1MjWYeyXZi8Q4dRrkGohFRfQdSUqL9yopB8LkSsHxeH5/SqQ68qYhR36JU/wHvgdERGmZw/jVKtdUazr6VN1KVE+9TaxHftL4qQCRpHNHvAmpttJ16S1lyto42PV/XVA3jZoFFajUmyP6PI9XaOzsl0NC1AtRcj+DcwZlOXoNkfWn9lvw+Y/ohpgx1btlZKsj5x+oQLt495XSrpqLGEziAS8cGDDiSFQQggkhBhxJBxNAgkhBioI4qCAQSYMru5+zaJHfna0JVoGSDQOaPmhR80WaVmqgTnePvia7ChSbzOHI+trhh5wrzSko9En1zty7QHxnygq4io2D4eQagOWvijrTw45hT9up2DY+OW/wAE4TQwVMpSBLsc1So2r1G5szd5OnK8HgKNLDU1o0UCU12A3J5ljuzHrMsqSZNMTdy0SJJKsmBIGAjxRQFFFFAUUaKFV6i30OolYpbYm19t5aeV3G3ePjLYKHEsLRqWWqoJGqvqrITzSoLFT3GV1XE0fQb6TT9RyErAfov6L9zBT+lNRxqe4fOOlAfZ6Pw9n4WkA8Hiw65grodiroUYHq10PeCR2ywHjrTN7EeIPyiKiQOHj54A1kzZM65yMwXMMxUG17b2vzhMsAoePUKupRxdT7R3QWTtklWAMUrWG9gBfuEIqyQWPaAwEcCK0kBAQEkBC0CBckXsPmBJCuD9k+78ZZEBEkBDCoPVPu/GGoLmNhppfX/aXBUAkrTRGFPZHGGPZGDPEmJeGHPZJeYPZKYoiIyxjKi0kapUZVRRcsduoDtJNgANSSBGwJNRFco6ZtQjgBwORZQTluNbHUX1sdIMUqkqus3XwvMkSrVo6byWDENPUS2iwxSRtJIEBFFHgNFC0qDP6Kk9vL27Q1PDrexYufVQZva2wlwVJYTBuRc2VetjlE0aOFb7KrTHX6b+06D3yRoU1N2JZ/0iWPgvL2S4M7zNP+8PhTJHgbaxTX+kj1G9i/jFGQcs6D/jSAddteY+MstAPy7x8YvwDf0vAfOGpwTel4D5w1OSAoGvgflE6x138D8o7SVWFiMGoxC19c602pgXGXKzBjpa97jrlxahjYn0ok7jOfbQgcw9PaAHcYeltLEqYEeIR5pDRxFFALT2bu/1CQp/M/EydPZu7/UINCermefaZqIKst4E9I/d+cpqT1e+WcHqx+719so0wY94EiSA/q5gFg8TiAiFyGYAeiiF2PUFUakySD+rxmH9XMDMwvD3qOtfEgZ0N6VEHMlHlnY7PWtu2y3svNm06mIA21MhQGreHzmZWJFawNg1RVNt7ebBsDy16oFwvmaxOuunVp7pU839c675KdNwSS3ptUXKt/R9C9+d+yX8gBAAsOzulZk+uqH/AMFD/MrfjAE4gjDPAmAbDYfObXtbWWcPQuzqqr0GylnObUqraILDZhuY3CvSbu+cNw785iP1qf5FGIDNh1tdyz25HRfBRpJioQLKoUf1yH4x8R6J7pQfDu9ZQGtT82xIu1i2cAGwIvp1yizVqgem/he3uG8rvjFX0VPsCD2tb4S5T4co3J7hZR7tffC08Ki6hBfrtc+06wmVj/Tm6l9rH35dY83opTL+uOaCfl3j4wzCCqfMfGSqE/pHuHzh6YgG9I9w+JlilMwoi7+B+Um0iu/gflJGKRl4s2de0/KFWRxXpiSWZinhUOkEJyPE/L2lRqPSNKoWRipIyWJHMXa8uDtQ0lmnnv8A/SqP9zV/wfzR1/KRSJt5mr/g/mjKPQbxXnBP+USkBrRqe1P5pFfyk0v7ir7U/mjKPRaezfd/1CCp/M/Ezn/JXysTGPUREdClPOS2WxGdRYZSeudAm3ifiZqJRBJ08SEOYgkWtp3yAgq4/rxEnO5xti8ZvKRcbjCW9F/YPxkv7YT1X9g/GZDJ8JPJpPJ7uT0eri1V40lh0X17B+MFV4/TFyUqexfxmYq6CVMQND4y+7keqOq4Vi1qqXUEDbW19L9Ur1x9d/8AYv8AlCB8n6qpRLNfKDrZWY6tbZQTzh3INYWO9RffSE9PG7JXDlMtjRfcd/yMruvTqH/w0f46stVl1Xv+RnkX5SvKzGYfGPQo1clPzVLZELEEFvSYHmW265vGXolSoBM3FcYop6dVF7C4v7J4ZV4xiap+sr1H73a3sBtKSVDnXX7S/ER4q+mPJ+uHZrG4y/MTR4ev1mI/WJ/kUpyH5MqxYPc3sLewgTssEPrK/wB9D/8Akg+URBsSvRPdB0h0x9w/xCWKy3FoJRZ1+4/8SfjAsxlEeDrEgaQosUoLiGigc8wgnHxHxEsMIBx8R8RLWYC46R7h8TDUxIOOl4D4tC0hMxRE38D8pIiMo18DJGSjMxfpiSWQxwOdbHnJrJPoeePeU2HBxVc/+Rp7DPJfKX/5Vb75+U1BhHDLEKIGssGRMqgV5XOkPijpKzvKO5/JOT9JrfqD/mJPUk+Z+JnkP5NMWtPE1CxILUWVbIz9LOh2UHSwJv2Tu/8AqyihyuwJubkKwG+ujDTfTUjQi4ktk+s2unEcoWNh1H4iczhPKYOtwLkM9wN7D0QOXX7B1y5T8oi1vM0w9TOKeVntlLFekdPR13mbePKYk5ZdbRwrbaX74vorSlhsViCy58qZrlbL0M1g2RuYuDYG+6N2TQbGFSc+RUC3LZra37dLW7Zz9PF1n+vKq5w7AASlXwra2tz5zUOMRjZXUkbgMCR3yOYGPTxq+3lAVwrnCVEBAJBvvt4a35252tzgeCYB6b08zE6rfolekyXIsTsAFHtjcaD+ZBXMoVwSw1A3t0QbnU27ASZfwrMzKzCx84tuor5tcpGpO1t7HfQTc4zc/HPld7/rcrpdlN9ARPCPyv0/+4t+oo/Bh8p7zWXVfvCeG/leH/cO/D0fjUE6EcHTS0jbpj7y/EQ1zcQT+mO8fKVXun5K96ve38QneYX85V70P+AD5Tg/yWWvUt+l7cy39953mH/O1f2P4TMpFp9jAH84v3H/AIkh22gSOmp/Rf4p+EKsRoo8COURSUUDlGEE6/EfEQpfqBPhb42kGv1AC4567jslQCoOn+yPi0LSEg46f7I+LQ9ISQDObOACLWJtlJO4vreFMlbWMYpGZjfSEdZHH+kI6mY/pTmcPxrySxFWtUqIUyO2YXZr7DfoztyZZw9suvXLB5c3kVif0P3m/lkf+i8T+h+838s9NbGUrkZ0uND0hGGJQ/bX94SmvK6/kNimFugP2m/lgV/J5iz9qn+834T1o4hPXX94SK4tLgZ1uTYdIanq3l01xvkh5H1cM1V67I1PzLAqha/pIxvcDQhSPGbvFcAlRNaQbKHQEroASbi4JO9jcWII3mnxPFhKNQ9aOt7EDMwsl77jNb2yWCTNSC62sRmINzrqxHK518ZLN6SuMw+akhBSw9EutyF1N7/77EgzV8jsmcFrjNm2GXMbgDNvoV27+uFx1RyCjLZw2pAuMlhmYctMpPeZ0PAMFlyBejZDdfZpfQ38eU58ZvJmOgw6aag6czY+8Sb4dDuinvAMmq2jzu2rLhU9Ref2V64jhkA0QDuAEN+J5nrkH23PtMDOfFogdSyq2XOFYjXKdhroSbDxj1W+uW/96u235tZhtwcMXZ1OYahlaxLZ+hc69Y310mriH+tX9an8Cznxtt7mJtb9RtV+8B7Zw/lr5CDG1vPisUdaKLlyhlIVn53B+1O1c6r94c+2LEfa/V/MzZHheL/J5XX0XR7dhX8ZlV/JLEobmlmsd1IM9pVg4JG2Zl/cYqfeDBBAdusjxBsfeJPJpS/JvhGRnzAi4Yi/UWE7XD/nandT+DTK4GlnP3T8RNah+dqfdp/64RaMgzgbycz8HT6Va5P50aaEfm6fXCrRqr1yJcetb2x/o452Phb4QNTDa6KfBvxhBPPD1h7RFA/R263/AK8YoGQYNvmPjCGDb5j4zTITjpfsj4mFSRcdP9kfEySyNJnlItE24/rkYzmSpGTxF7Mvfb2xK0qcVxah1G+u/IRkxS+sJje61nS9eSAuJTXFJ6w9s0cEwZbg3F5fqOE47wLzmMVM4AdGqHQFhkKqVHfe9+w9Uq1PI+qWAzqVv6tiR77H2zq8Th1biSMTquGzBe3O63PZZzNl02iTWts+OCqeTL0KT1C4YopZgVABCi5A6jvL/BeAMhStnu2UsFCjL0x7SdZ0PlJhlfC1gTboM1+1OmPesfgDj6NRJ1JpoSe9QZZEttiljcG7Jq50s7an0Q4IXTTZWO3ITU4aDl6Q1329bUlTvvff5a5vFOI1UrlVQtQydLoXBJuWBflZb/7zNx3llkVkp0/rLnW9wCSSdxY8xL1GbG5xO12QnV7AdztTT4hptpe/RJBsdQbHcc55T/a1aqudqjGohbbL9gl0ygC1gCT+yZ6b5L48Vlzjki6ndswBudNDE/TpcZKvrt++fwg2Sr67/wDsb8Jt5oiZVxhebq+u/wC+fwletTr8nf8AfP8ALOkisJDHL8PSsM4qEsCy2NybAX02HZLVVHNQG3RDI4PWVCix6tjrNsoDH82LjwhKjTxSsyg3U3Frjc35HnD19z+rPxmLxqogQqlQo+ZRsRa7Ac7WMyMbxaspajRrUziFXKxqKWBQoGHotmGpGtjz0lVNsXkorp9Y4bIo3ZyTr4k3PULnkZLB4hMoRGzMERrXGd898pAvqWsW06xe1xOI4RxSrlLVWTNnyh2JUIC2q5ydEZgLKq3a3UcwscOdytKiWF/NVEYuhcF8KQj0VoqUV2yAMpctcX0mR1uB48yMVZUFT1S6Z7HllBze6bHDvKSlUJaxDMADyta9gQdQdTPJeNcacUqaUnxSmuAabFsPRQpcXZadABgLbZiPdL3BqL00ABzbd9ucXpZ29ppYtG2YSOGHSqHkXBH/AK0HxBnl9HiTKxuToJp4Xj7gA5jbqvJq49Gjzk8N5UcmF5r0ON0mYoWyutrqwINjsbHl2y6jVigfpCesIpRzxkH+Y+MdmtqdAOfKZb8colwivna4By6qLn1tj4XmmGk46X7PzklEqPi1zbHbbnvz6ozYknsHUD85Ni4sYmsFtrr1b8jM2s7ueof1yhWba0g0xy7ajPq4cX+Zk1piFqKbxiJzxrUcgl/BMAtrjeUcsdEI2llxL2fGAfSaD3GqVk36wjj+AzQdhcaj2zDrUKrYim3R82iOf0s7DL7LfCXWptpN6lP5QuPo1fUfmn5/oGGw6qiIoIAVEG45KBM3i+Gd6NRBqzI4G25U2lnD4VyiZ7B8q5gNgbC4HZJtM6KoMzEWBB01bS2XXTvt7uucZiMORia9MIVDtZDst1pecNj1Etrb5zuaWGYNe/Pe3K2sNicAtTKWFyjFgdjqCD7j7hLmpf489/sBvOImHKh/Ns9RixYZlbKSOQ5iw656T5OYRaNNEFtEUXtYmwGptK9LAoHL6ligTU/ZBJt7T8OqaNNLWtsBb3Szov1pecgUxakbgHXQ98r5rbwNVlRSziwA1J20H/MspWj9IX1l9ogDjCHsbFOsHW/bMatxikoZsjkKFJKroQ2xBJAiTjFIsVAa4QP9k9EgEEANfn1cpnz4/q+PL8bK12ubazJ4/iWWtTYGylWDdWhBH8Rk8Pxiky5g++moI157yh5Qg1KaulzkvfSxAI3I6to38Mz61BZ10YG/ZcTM4jw6pYtSCCpY2uMtz3iZPDeJshAO3Vy751mGxSuOUu6mY8vxeDxFI5amGL0/QJKZkFMp9YyhNqjm4zW6IsBoLQnD8WGYhagDsyVKbt0cuLor0c9/R89SUqe1WE9SZRbXUdtrTOx/A8PVBD0kcdRRdbajWMNeP4FRisQ9VcyIGbzSMb5EZ2cL3Au2nK865CyA32AFj1zSxXkgiEvhwEbmv2D4cvCUA7o2WqhU8r+ie47GZ5fWoLSbOFQbvbxuLzawuFwZQUszBwbhwGNmvfnoV7NPCcVxXymNB7UkRqlrMzgkAH7IAI1tz7bdcs+TnEUxOZWOSqvSyDVWS9rqT1XAN+sTN8pNkWeN+ulrcIqo2f06a9L6vpNZQW1QdJr2Astyc243AKOOqLlRyGctTS1ROl5x1z1GBIOZgugtntbcawz4sooUXygWGvVOdxvGM9RELMQlVcxLlUUsjhQ777kdEWvcCa48ksdP/abtcooVLsAM67AkX6VYHW19QN4pznA+JotBFWtVKjMBkw3Q9JvR6J08TFL5X8TFriDV6zuHdigdgBstgxA0GnjLPDOFBTfnob902voShmJuSWJ7NTC5PZF2/RAIAdI4JkmESyaFrHj2jlJKsBcR80J5q/dJiiI7FUkmERYcUhJLTlxFZ11Hj8IULCFBeObCXAxUWPdMitxyxIRAVGly29u7lIca4/SRWRXU1NiBqV6722M5FsenVc9wtEHWjj7eov7x/COPKFvUUftGcU+P6kXx1lV65P8AsAPhLlHfDjp9Rf3odePN6i3755yK52ubd5v4SxhuIFGVTZlO2guOwy4O+fjZYWKgC4vrtY3+Ubyiao9INTYecUq4GYXuAQRbxI1nNo406PuFpb88DbS91HMA3trpf+rxiOf4jWrBAcrqWbpUsjsEKn00KsGW9tsxEFhnrpURkDCoQLtlUBtNMzebJ2uNST2zpauJyKWK6AE3/oyqnF0IUgrqbEG9x27zHrjp7KhgOJVcouhs7ZTozMGIGuUhVyzreHJURFdlAOY3S/2b6XHIka25XnLf2qLm2S2ttT4c5JuKDlk8Q3xBl48JE5cryW8fgHAetkC0zVfKqnVUuMj9gsfCQ4fxMobE6fGJPKBFQC2utwPRudOfKwHKYtXiCXJUBRuBe9u6XxZ13J49TVdbk+qPnLOA4qtW+W4KgEqRc2N7EHntPN2xmbadN5KVgpcsdTlUeFyfiJr5EdZnVtQLHrKyljqSshD5WJBsCuhPKGqrmGjMp6wR8xMTi6kkWZw42IF7j2WMxasjx7Flld1fSoGIYHcNzmx5JUKnn0qhWFJQ2ZypyEFSLA2sdSPZO0GMXMFroL8nKXU+JHRMtYyoqIWPogeEl59ZjWMjjXEMq6G7EgKOsnaYlDOlM1CEYKaFbzjg+bQkkMUUem2lr9thA08Wlastx9UjLqTdBfMASN26QUBRveXKFNsqWKLnwhUNWK5rg/Ypi4Ven1HT3pMKw+MVwKz5atUqSGB0AIYBtBYWGunZaKdBhOPAouarWzWsclABbjTo9E6af8bRS7fxHqTpqe8yDJCO2p74NjFqBsI1oRhFlmGkRCJT5mMoAk/OCUSIitBtUEXnI1MEtFaD84I3nhLsTCfecJ5crXV1e5OHsAACcqtzzDrPIzuTUB23mN5RVgtIobHP0cp59cauPLWFjmQ3HNeY67dfdJpxFecjR4ezvVCOUVGygnW5tcg68tIqVJ/Omizahc2YAAm9rDWb2GCDHX2UnuUmNWquN1y/eNpcODy3ILE25sNPACMlVWBSoMyEEdq30up5GPKGKdKm7nQlvuiw7bsYfhlHOSR0cjlCOeZesnlrNNKGRVUG6AABtL6DS9ucDhcFlZ2D6OwawUaECxN+d99pNp0vUazB1WwIJt177e+3shhiyDbKuw3Lb2G/vgFQaEDURyJZKWg8X4n9UUIAJItbNy3OunIe2ck2IN/+Zo8arAtlHLT8ZjGEWhij1n2yYxjW5+2UxJKIFv6Wx6/bCI7cvx+MAiyzSEo0MIvtm5hsSUtaY+BQmwHMzoOKcP8ANkEHNTPPmrdR+Rk5fCfW/wAN4sG0Pv5zYDhhPOVqFToe6a2C44UUk9JraC9h3mYlWxuYjAsxIbIU69b+ImRxTgZqJkDtk9XlbqvvaXML5VoQQ6gMBfTmBva/wkv+pqHJR+7/ALS4nbjH8m3pkMhCsGDC1yCVIK3B7QJWJWkUZitJ0cZ3YF3dHclwmmgBY35679fdDyjT1V9+3sjnjaH7IP7MYa8yxfFAjstPEVWTMSCqLY5jmNrnrJinpv8AaSeoP3IprIa6VxqZExRTnWoZjGDxRTKmLXjXEUUggxivFFAiWgqrxRQBh7TkeN43M5BOi3sNeVrn2mKKOP0c1wer9WX06dR2533ygadwgqTgYlzfTzYtud7WiinZGk+KUggHXb7XbeZ9UaxRQVawGMt0Tqp5GaDaWtrfY/jFFLGUlbSDxlfKhPPYd5iilHJ4prtK8UUglCIIooFhBLNIaxRSjf4LTBqIL2uw18dPfb2zrVIYFSLgixB2MUUI5vi2DNJutG9E8+49o65nu1gffFFMX63PivT1N5dpU+yKKUqylPWXadKKKGVjzRiiigf/2Q=="),
        //};

        private ApplicationDbContext _context;

        public AppartmentsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Appartments
        public ActionResult Index(string city)
        {
            List<Apartment> apartements;
            if (string.IsNullOrEmpty(city))
            {
                apartements = _context.Apartments.ToList();
            }
            else
            {
                city = city.ToLower();
                apartements = _context.Apartments.Where(apt => apt.City.ToLower().Contains(city)).ToList();
            }
            
            var apartmentsDtos = apartements.Select(Mapper.Map<Apartment, ApartmentDtos>).ToList();

            var viewModel = new ApartmentsViewModel()
            {
                Apartments = apartmentsDtos
            };

            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            //if (id >= apartements.Count)
            //    return HttpNotFound();
            //var apartment = apartements[id-1];

            var apartment = _context.Apartments.SingleOrDefault(apt => apt.Id == id);

            if (apartment == null)
            {
                return HttpNotFound();
            }

            var apartmentDto = Mapper.Map<Apartment, ApartmentDtos>(apartment);

            return View(apartmentDto);
        }

        public ActionResult New ()
        {
            var apartment = new ApartmentDtos();


            return View("ApartmentForm",apartment);
        }

        public ActionResult edit(int id)
        {
            var apartment = _context.Apartments.SingleOrDefault(apt => apt.Id == id);
            if (apartment == null)
            {
                return HttpNotFound();
            }

            var apartmentDto = Mapper.Map<Apartment, ApartmentDtos>(apartment);

            return View("ApartmentForm", apartmentDto);
        }

        public ActionResult Save(ApartmentDtos apartmentDtos)
        {
            if (apartmentDtos.Id == 0)
            {
                var apartment = Mapper.Map<ApartmentDtos, Apartment>(apartmentDtos);
                apartment.OwnerId = "David";
                _context.Apartments.Add(apartment);
            }
            else
            {
                var apartmentInDb = _context.Apartments.Single(apt => apt.Id == apartmentDtos.Id);
                Mapper.Map(apartmentDtos, apartmentInDb);
            }

            _context.SaveChanges();

            return RedirectToAction("", "Appartments");
        }


    // Appartments/stam/id?sortBy=fuck
    [Route("apartments/theroute/best/{id:range(1,5)}/{sortBy}")]
        public ActionResult stam(int? id, string sortBy)
        {

            //return Content("Stam actione");
            //return HttpNotFound();
            //return RedirectToAction("Index", "Home");

            if (string.IsNullOrEmpty(sortBy))
            {
                sortBy = "none";
            }
            return Content("Stam action" + id + ", sort By:" + sortBy);
        }
        public ActionResult RealStam()
        {
            //var model = new Stam(1, "Moshe", true);
            //return View(model);

            var stams = new List<Stam>()
            {
                new Stam(1, "Moshe", true),
                new Stam(2, "Moshit", false)
            };

            var viewModel = new RealStamViewModel()
            {
                Stams = stams
            };

            return View(viewModel);
        }


    }
}