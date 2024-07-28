   1. Prerequisites
      
     a. Download .Net 6.0.0 64 bit 
     b. Download Visual Studio 2022 
     c. Setup your aws credentials file under (C:\Users\{user}\.aws}
         c.1 Sample aws folder should like this: 
            ![image](https://github.com/user-attachments/assets/3184ede1-f499-47c5-9def-02e203ae04fb)

         c.2 credentials file should have below config
            [default]
              aws_access_key_id=XXXXXXXXXXXXXXXXXX
              aws_secret_access_key=XXXXXXXXXXXXXXXXXXXX

          c.3 config file should have below config
             [default]
              region = us-west-1(your region)

     
   3. Clone Repo: https://github.com/srujana-gajari/ImageManipulationApi
   4. Copy an image which needs to be uploaded to S3 bucket in the folder(~/ImageManipulationApi/ImageManipulationApi) where the project file is located.
   5. Lets run the Visual Studio in local to launch endpoints in swagger by selecting IIS Express like below
    ![image](https://github.com/user-attachments/assets/c4a28e68-c321-4d79-9bcb-dc61384f26c8)
   6. Your swagger should like below: 
      ![image](https://github.com/user-attachments/assets/3db51bcc-574c-4262-b399-9c77093b87d4)

You are now ready with endpoints.
