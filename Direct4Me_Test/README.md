# Direct4Me_Test

ASP.NET Core 3.1 - Simple API for User Management, Authentication , Registration , Articles and DeliveryServices

POSTMAN
Count of articles in delivery
GET
http://localhost:4000/deliveryServices/count

[
    {
        "title": "1696",
        "count": 4
    },
    {
        "title": "GL",
        "count": 4
    },
    {
        "title": "PS",
        "count": 4
    },
    {
        "title": "UP",
        "count": 4
    }
]

POSTMAN
Save article with only number of message from delivvery
POST
http://localhost:4000/articles/register

[{
    "externalId": "PS001638355AT"
}]

DocerFile is in project
Start with

docker build -t direct4me_test .