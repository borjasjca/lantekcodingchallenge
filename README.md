# Lantek Coding Challenge by Borja San Juan


## 1. Coding exercise: Comments

### 1.1 About exercise

I dedicated about 12 hours solving this exercise, but I spent most of the time on this exception: 

**_System.Net.WebException: The request was aborted: Could not create SSL/TLS secure channel._**

The problem was caused by the security protocol, only supporting TLS 1.2 at server side, and I found the solution in internet after a lot of trials, removing the code for using different libraries and classes...

I am used to work with bussiness layer, retrieving and managing data from DB, so this exercise it's been a real challenge for me.

### 1.2 About Test

I have never been requested to add a Test Unit for 18 years in my actual job, so this has been another challenge for me. 

### 1.3 About GitHub

It is also the first time I work with GitHub (so sure you noticed it!!). That's been another discovery and I hope I have managed my first repository properly, due the circumstances.

### 1.4 Summary

The challenge has allowed me to discover more tools and libraries in three days than in 18 years. Thanks for that!! 


## 2. Technical Questions

**_1. How long did you spend on the coding test? What would you add to your solution if you had more time? If you didn't spend much time on the coding test, use this as an opportunity to explain what you would add._**
   
   I spent about 12 hours.
   
   If I had more time, I would improve the presentation of the results, working on the tabulation and allowing the user not to exit the application for new requests.
   
   I would also send the requests in asyncronous mode.
   
**_2. What was the most useful feature added to the latest version of your chosen language? Please include a snippet of code that shows how you've used it._**

   Honestly, I must admit that I am used to work with the same structures and classes than when I started in my actual company, 18 years ago. That's one of the reasons because of I am looking for new laboral experiences.
   
**_3. How would you track down a performance issue in production? Have you ever had to do this?_**

   It's not among my responsabilities, but I know there are some tools, like Dynatrace, or some browsers' tools to do it.
   
**_4. How would you improve the Lantek API that you just used?_**

   Maybe I would enable the Lantek API to allow more security protocols.
