/*
 * Control a servo motor, provide teleoperation via GUI from Visual Studio
 * Laura Boccanfuso, Lisa Chen, Colette Torres, 2015
 * Test
 */

#include <Servo.h> 

// create servo objects to control each servo
Servo myservo3;
Servo myservo4;   // right eyeball up/down
Servo myservo5;   // left eyeball up/down
Servo myservo6;   // right eyeball left/right
Servo myservo7;   // left eyeball left/right
Servo myservo8;   // jaw
Servo myservo9;   // right lip
Servo myservo10;  // left lip
Servo myservo11;  // neck left/right
Servo myservo12;  // neck up/down
Servo myservoA0;  // left eyelid
Servo myservoA1;  // right eyelid
Servo myservo2; //left eyebrow



void setup() 
{
  
  Serial.begin(9600); //begins serial communication
  delay(500);
} 

void loop() 
{ 
  char pos='2';

  if (Serial.available()){
    delay(50);
    while(Serial.available()>0){
      pos=Serial.read();   
      

      if(pos=='0') {
        // SMILE
        myservo8.attach(8);   // jaw (20-110, open-to-c)
        myservo10.attach(10); // 
        myservo9.attach(9);   //
        myservo12.attach(12); // 
        myservo11.attach(11); //  
        myservoA0.attach(A0); //  
        myservoA1.attach(A1); //  
        myservo6.attach(6); // 
        myservo7.attach(7);  // 
        myservo4.attach(4); // 
        myservo5.attach(5);  
        myservo2.attach(2);
        myservo3.attach(3);
       
        myservo8.write(100);   // 
        myservo10.write(-30);  // 
        myservo9.write(220);   // 
        myservo12.write(10);   //
        myservo11.write(75);    // 
        myservoA0.write(40);   //
        myservoA1.write(15);  
        myservo6.write(25); // 
        myservo7.write(68);  // 
        myservo4.write(130);
        myservo5.write(60);
        myservo2.write(150);
        myservo3.write(130);
      
        delay(400);
        
        myservo8.detach();   //  
        myservo10.detach();  // 
        myservo9.detach();   // 
        myservo12.detach();  //
        myservo11.detach();  // 
        myservoA0.detach();  //  
        myservoA1.detach();  //  
        myservo6.detach(); // left right
        myservo7.detach();  // left right
        myservo4.detach(); // up down
        myservo5.detach();
        myservo2.detach();
        myservo3.detach();
        delay(100);
      }
      else if(pos=='1') {
        // SAD
        
        myservo10.attach(10); // 
        myservo9.attach(9);   // 
        //myservo12.attach(12); // 
        //myservo11.attach(11);  // 
        myservoA0.attach(A0); // 
        myservoA1.attach(A1);  // 
        myservo6.attach(6); // 
        myservo7.attach(7);  // 
        myservo4.attach(4); // 
        myservo5.attach(5);  
        myservo2.attach(2);
        myservo3.attach(3);
        
        myservo2.write(130);
        myservo6.write(25); // 
        myservo7.write(68);  // 
        myservo4.write(130);
        myservo5.write(60);
        myservo10.write(150);  // left lip down
        myservo9.write(10);  // right lip down
        myservoA0.write(20);
        myservoA1.write(15);
        myservo3.write(100);
        delay(400);
        
        myservo2.detach();
        myservo10.detach(); //
        myservo9.detach(); //
        myservoA0.detach(); // 
        myservoA1.detach();  // 
        myservo6.detach(); // left right
        myservo7.detach();  // left right
        myservo4.detach(); // up down
        myservo5.detach();  // up down
        myservo3.detach();
      }
      else if(pos=='2') {
        // NEUTRAL
        myservo8.attach(8); //
        myservo10.attach(10); // 
        myservo9.attach(9); // 
        myservo12.attach(12); // 
        myservo11.attach(11);  //
        myservo6.attach(6); // 
        myservo7.attach(7);  // 
        myservo4.attach(4); // 
        myservo5.attach(5);  // 
        myservoA0.attach(A0); // 
        myservoA1.attach(A1); // 
        myservo2.attach(2);
        myservo3.attach(3);
        
        myservo8.write(115);  // 
        myservo10.write(60);  // 
        myservo9.write(120);  // 

        delay(100);
        myservo7.write(68);  //  
        myservo6.write(25);  // 
        delay(200);
        myservo4.write(130); //
        myservo5.write(60);  // 
        delay(100);
        myservoA0.write(40); // 
        myservoA1.write(15); //
        myservo12.write(20); // 
        myservo11.write(75);  //
        myservo2.write(100);
        myservo3.write(130);
        delay(250);
        
        myservo8.detach(); // 
        myservo10.detach(); // 
        myservo9.detach(); // 
        //myservo12.detach(); //
        myservo11.detach();  // 
        myservo6.detach(); // 
        myservo7.detach();  // 
        myservo4.detach(); // 
        myservo5.detach();  // 
        myservoA0.detach(); // 
        myservoA1.detach(); // 
        myservo2.detach();
        myservo3.detach();
      }
      else if(pos=='3') {
        // BLINK
         myservoA0.attach(A0);
         myservoA1.attach(A1);
        
        
         myservoA0.write(0);
         myservoA1.write(70);
         delay(150);
         myservoA0.write(40); //open eyelid
         myservoA1.write(15);
         delay(150);
         
         myservoA0.detach();
         myservoA1.detach();
         delay(100);
      }
      else if(pos=='4') { 
        //JAW DROP BIG
        myservo8.attach(8);
        myservo8.write(80);   // jaw opens big
        delay(50);
        myservo8.detach();
      }
      else if(pos=='5') { 
        myservo8.attach(8);
        myservo8.write(90);   // jaw opens medium
        delay(50);
        myservo8.detach();
      }
      else if(pos=='6') { 
        //JAW DROP SMALL
        myservo8.attach(8);
        myservo8.write(105);   // jaw opens small
        delay(50);
        myservo8.detach();
      }
      else if(pos=='7') {
        //JAW SHUT
        myservo8.attach(8);
        myservo8.write(115);   // jaw closes
        delay(50);
        myservo8.detach();
      }
      else if(pos=='8') {
        //EYES RIGHT
        myservo6.attach(6);
        myservo7.attach(7);
        myservo6.write(52);   // eyes right
        myservo7.write(95);
        delay(350);
        myservo6.detach();
        myservo7.detach();
        delay(100);
      }
      else if(pos=='9') {
        //EYES LEFT
        myservo6.attach(6);
        myservo7.attach(7);
        myservo6.write(0);   // eyes left
        myservo7.write(50);
        delay(350);
        myservo6.detach();
        myservo7.detach();
      }
       else if(pos=='10') {
        myservo4.detach();     // stop
        myservo5.detach();
        myservo6.detach();
        myservo7.detach();
        myservo8.detach();
        myservo9.detach();
        myservo10.detach();
        myservo11.detach();
        myservo12.detach();
        myservoA0.detach();
        myservoA1.detach();
        delay(150);
      }
       
     else if(pos=='A') {
        myservo11.attach(11);
         myservoA0.attach(A0); //  
        myservoA1.attach(A1);
        myservo11.write(50); 
        myservoA0.write(40); //  
        myservoA1.write(15);   // head left
        delay(350);
        myservo11.detach();
        myservoA0.detach(); //  
        myservoA1.detach();
        delay(100);
      }
      else if(pos=='B') {
        myservo11.attach(11);
        myservoA0.attach(A0); //  
        myservoA1.attach(A1);
        myservoA0.write(40); //  
        myservoA1.write(15);
        myservo11.write(110);   // head right
        delay(350);
        myservo11.detach();
         myservoA0.detach(); //  
        myservoA1.detach();
        delay(100);
      }       
      else if(pos=='C') {
        //HEAD UP
        myservo12.attach(12);
        myservo4.attach(4);
        myservo5.attach(5);
        myservo6.attach(6);
        myservo7.attach(7);
        myservo12.write(10);   // head up
        myservo4.write(80);   // eyes up
        myservo5.write(95);
        myservo6.write(25); // 
        myservo7.write(68);  // 
        delay(200);
        myservo12.detach();
        myservo4.detach();
        myservo5.detach();
        myservo6.detach(); // left right
        myservo7.detach();  // left right
        delay(100);    
      }
      else if(pos=='D') {
        //HEAD DOWN
        myservo6.attach(6); // 
        myservo7.attach(7);  // 
        myservo4.attach(4); // 
        myservo5.attach(5);  
        myservo12.attach(12);
        
        myservo6.write(25); // 
        myservo7.write(67);  // 
        myservo4.write(130);
        myservo5.write(60);
        myservo12.write(50);   //  head down
        delay(200);
        
        myservo12.detach();
        myservo6.detach(); // left right
        myservo7.detach();  // left right
        myservo4.detach(); // up down
        myservo5.detach();  // up down
      }    
     else if(pos=='E') {
        //WINK
        myservo6.attach(6); // 
        myservo7.attach(7);  // 
        myservo4.attach(4); // 
        myservo5.attach(5);  
        myservo8.attach(8);   // jaw (20-110, open-to-c)
        myservo10.attach(10); // 
        myservo9.attach(9);   //
        myservo12.attach(12); // 
        myservo11.attach(11); //  
        myservoA0.attach(A0); //  
        myservoA1.attach(A1); //  
        myservo2.attach(2);
        myservo3.attach(3);
        
        myservo2.write(100);
        myservo6.write(25); // 
        myservo7.write(67);  // 
        myservo4.write(130);
        myservo5.write(60);
        myservo8.write(105);   // 
        myservo10.write(-30);  // 
        myservo9.write(220);   // 
        myservo12.write(10);   //
        myservo11.write(75);    // 
        myservoA0.write(40);   //
        myservoA1.write(15);   //
        myservo3.write(130);
        delay(400);
        
        myservo2.detach();
        myservo8.detach();   //  
        myservo10.detach();  // 
        myservo9.detach();   // 
        myservo12.detach();  //
        myservo11.detach();  // 
        myservoA0.detach();  //  
        myservoA1.detach();  //  
         myservoA1.attach(A1);
         myservoA1.write(60);
         delay(100);
         myservoA1.write(0);
         delay(150);
         myservoA1.detach();
         myservo6.detach(); // left right
        myservo7.detach();  // left right
        myservo4.detach(); // up down
        myservo5.detach();  // up down
        myservo3.detach();
      }   
      else if(pos=='F') {
        // CONFUSED
        myservo8.attach(8); //
        myservo10.attach(10); // 
        myservo9.attach(9); // 
        myservo12.attach(12); // 
        myservo11.attach(11);  //
        myservo6.attach(6); // 
        myservo7.attach(7);  // 
        myservo4.attach(4); // 
        myservo5.attach(5);  // 
        myservoA0.attach(A0); // 
        myservoA1.attach(A1); // 
        myservo2.attach(2);
        myservo3.attach(3);
        
        myservo2.write(115);
        myservo8.write(115);  // 
        myservo10.write(-20);  // 
        myservo9.write(10);  // 
        delay(100);
        myservo7.write(95);  //  
        myservo6.write(52);  // 
        delay(200);
        myservo4.write(60); //
        myservo5.write(90);  // 
        delay(100);
        myservoA0.write(140); // 
        myservoA1.write(50); //
        myservo12.write(20); // 
        myservo11.write(75);  //
        myservo3.write(100);
        delay(150);
        
        myservo2.detach();
        myservo8.detach(); // 
        myservo10.detach(); // 
        myservo9.detach(); // 
        //myservo12.detach(); //
        myservo11.detach();  // 
        myservo6.detach(); // left right
        myservo7.detach();  // left right
        myservo4.detach(); // up down
        myservo5.detach();  // up down
        myservoA0.detach(); // 
        myservoA1.detach(); // 
        myservo3.detach();
      }
      if(pos=='G') {
        // SURPRISED
        myservoA0.attach(A0);   //
        myservoA1.attach(A1);   //
        myservo8.attach(8);   // jaw (20-110, open-to-c)
        myservo10.attach(10); // 
        myservo9.attach(9);   //
        myservo12.attach(12); // 
        myservo11.attach(11); //  
        myservo6.attach(6); // 
        myservo7.attach(7);  // 
        myservo4.attach(4); // 
        myservo5.attach(5);  // 
        myservo2.attach(2);
        myservo3.attach(3);
        
        myservo2.write(130);
        myservoA0.write(130);   //
        myservoA1.write(-20);   //
        myservo8.write(80);   // 
        myservo10.write(60);  // 
        myservo9.write(120);   // 
        myservo12.write(10);   //
        myservo11.write(75);    // 
        myservo6.write(25); // 
        myservo7.write(67);  // 
        myservo4.write(130);
        myservo5.write(60);
        myservo3.write(100);
        delay(400);
        
        myservo2.detach();
        myservo8.detach();   //  
        myservo10.detach();  // 
        myservo9.detach();   // 
        myservo12.detach();  //
        myservo11.detach();  // 
        myservoA0.detach();  //  
        myservoA1.detach();  //  
         myservo6.detach(); // 
        myservo7.detach();  // 
        myservo4.detach(); // 
        myservo5.detach();  //
       myservo3.detach(); 
      }
      else if(pos=='H') {
        // ANGRY
        myservo6.attach(6); // 
        myservo7.attach(7);  // 
        myservo4.attach(4); // 
        myservo5.attach(5);  
        myservo10.attach(10); // 
        myservo9.attach(9);   // 
        //myservo12.attach(12); // 
        //myservo11.attach(11);  // 
        myservoA0.attach(A0); // 
        myservoA1.attach(A1);  
        myservo2.attach(2);  // 
        myservo8.attach(8);
        myservo3.attach(3);
        
        myservo10.write(145);  // left lip down
        myservo9.write(35);  // right lip down
        myservo8.write(90);
        //myservo12.write(110); // left eyebrow sad
        //myservo11.write(80); // right eyebrow sad
        myservoA0.write(13);
        myservoA1.write(40);
        myservo2.write(30);  
        myservo6.write(25); // 
        myservo7.write(67);  // 
        myservo4.write(130);
        myservo5.write(60);
        myservo3.write(170);
        delay(400);
        
        myservo10.detach(); //
        myservo9.detach(); //
        myservo8.detach();
        //myservo12.detach(); // 
        //myservo11.detach();  // 
        myservoA0.detach(); // 
        myservoA1.detach();  // 
        myservo6.detach(); // left right
        myservo7.detach();  // left right
        myservo4.detach(); // up down
        myservo5.detach();  // up down
        myservo3.detach();
      }
     
      else if(pos=='I') {
        // CROSS EYES
        myservo8.attach(8); //
        myservo10.attach(10); // 
        myservo9.attach(9); // 
        myservo12.attach(12); // 
        myservo11.attach(11);  //
        myservo6.attach(6); // 
        myservo7.attach(7);  // 
        myservo4.attach(4); // 
        myservo5.attach(5);  // 
        myservoA0.attach(A0); // 
        myservoA1.attach(A1); // 
        myservo2.attach(2);
        myservo3.attach(3);
        
        myservo2.write(130);
        myservo8.write(90);  // 
        myservo10.write(-20);  // 
        myservo9.write(10);  // 
        //myservo.write(80);  // 
        //myservo.write(100); //
        delay(100);
        myservo7.write(105);  //  
        myservo6.write(-30);  // 
        delay(200);
        myservo4.write(170); //
        myservo5.write(25);  // 
        delay(100);myservo3.attach(3);
        myservoA0.write(90); // 
        myservoA1.write(40); //
        myservo12.write(20); // 
        myservo11.write(75);  //
        myservo3.write(140);
        delay(150);
        
        myservo2.detach();
        myservo8.detach(); // 
        myservo10.detach(); // 
        myservo9.detach(); // 
        //myservo12.detach(); //
        myservo11.detach();  // 
        myservo6.detach(); // left right
        myservo7.detach();  // left right
        myservo4.detach(); // up down
        myservo5.detach();  // up down
        myservoA0.detach(); // 
        myservoA1.detach(); // 
        myservo3.detach();
      }
      else if(pos=='J') {
        // AWKWARD
        myservo8.attach(8); //
        myservo10.attach(10); // 
        myservo9.attach(9); // 
        myservo12.attach(12); // 
        myservo11.attach(11);  //
        myservo6.attach(6); // 
        myservo7.attach(7);  // 
        myservo4.attach(4); // 
        myservo5.attach(5);  // 
        myservoA0.attach(A0); // 
        myservoA1.attach(A1); // 
        myservo2.attach(2);
        myservo3.attach(3);
        
        myservo8.write(110);  // 
        myservo10.write(170);  // 
        myservo9.write(120);  // 
        //myservo.write(80);  // 
        //myservo.write(100); //
        delay(100);
        myservo7.write(0);  //  
        myservo6.write(-60);  // 
        delay(200);
        myservo4.write(130); //
        myservo5.write(60);  // 
        delay(100);
        myservoA0.write(30); // 
        myservoA1.write(30); //
        myservo12.write(20); // 
        myservo11.write(75);  //
        myservo2.write(115);
        myservo3.write(100);
        delay(150);
        
        myservo2.detach();
        myservo8.detach(); // 
        myservo10.detach(); // 
        myservo9.detach(); // 
        //myservo12.detach(); //
        myservo11.detach();  // 
        myservo6.detach(); // left right
        myservo7.detach();  // left right
        myservo4.detach(); // up down
        myservo5.detach();  // up down
        myservoA0.detach(); // 
        myservoA1.detach(); // 
        myservo3.detach();
      }
      else if(pos=='K') {
        // FUNNY FACE
        myservo8.attach(8); //
        myservo10.attach(10); // 
        myservo9.attach(9); // 
        myservo12.attach(12); // 
        myservo11.attach(11);  //
        myservo6.attach(6); // 
        myservo7.attach(7);  // 
        myservo4.attach(4); // 
        myservo5.attach(5);  // 
        myservoA0.attach(A0); // 
        myservoA1.attach(A1); // 
        myservo2.attach(2);
        myservo3.attach(3);
        
        myservo2.write(115);
        myservo8.write(80);  // 
        myservo10.write(-30);  // 
        myservo9.write(220);  // 
        //myservo.write(80);  // 
        //myservo.write(100); //
        delay(100);
        myservo7.write(-30);  //  
        myservo6.write(70);  // 
        delay(200);
        myservo4.write(40); //
        myservo5.write(25);  // 
        delay(100);
        myservoA0.write(20); // 
        myservoA1.write(40); //
        myservo12.write(20); // 
        myservo11.write(75);  //
        myservo3.write(140);
        delay(150);
        
        myservo2.detach();
        myservo8.detach(); // 
        myservo10.detach(); // 
        myservo9.detach(); // 
        //myservo12.detach(); //
        myservo11.detach();  // 
        myservo6.detach(); // left right
        myservo7.detach();  // left right
        myservo4.detach(); // up down
        myservo5.detach();  // up down
        myservoA0.detach(); // 
        myservoA1.detach(); // 
        myservo3.detach();
      }
     else if(pos=='L') {
        // AFRAID
        
        myservo2.attach(2);
        myservo10.attach(10); // 
        myservo9.attach(9);   // 
        //myservo12.attach(12); // 
        //myservo11.attach(11);  // 
        myservoA0.attach(A0); // 
        myservoA1.attach(A1);  // 
        myservo6.attach(6); // 
        myservo7.attach(7);  // 
        myservo4.attach(4); // 
        myservo5.attach(5);
        myservo8.attach(8);  
        myservo3.attach(3);
        
        myservo2.write(130);
        myservo6.write(25); // 
        myservo7.write(67);  // 
        myservo4.write(160);
        myservo5.write(30);
        myservo10.write(100);  // left lip down
        myservo9.write(50);  // right lip down
        //myservo12.write(110); // left eyebrow sad
        //myservo11.write(80); // right eyebrow sad
        myservoA0.write(20);
        myservoA1.write(15);
        myservo8.write(105);
        myservo3.write(100);
        delay(400);
        
        myservo2.detach();
        myservo10.detach(); //
        myservo9.detach(); //
        //myservo12.detach(); // 
        //myservo11.detach();  // 
        myservoA0.detach(); // 
        myservoA1.detach();  // 
        myservo6.detach(); // left right
        myservo7.detach();  // left right
        myservo4.detach(); // up down
        myservo5.detach();  // up down
        myservo8.detach();
        myservo3.detach();
      }
      else if(pos=='M') {
        //SLEEPY
        myservo8.attach(8); //
        myservo10.attach(10); // 
        myservo9.attach(9); // 
        myservo12.attach(12); // 
        myservo11.attach(11);  //
        myservo6.attach(6); // 
        myservo7.attach(7);  // 
        myservo4.attach(4); // 
        myservo5.attach(5);  // 
        myservoA0.attach(A0); // 
        myservoA1.attach(A1); // 
        myservo2.attach(2);
        myservo3.attach(3);
        
        myservo2.write(100);
        myservo8.write(100);  // 
        myservo10.write(148);  // left lip down
        myservo9.write(18);  // right lip down
        delay(100);
        myservo7.write(67);  //  
        myservo6.write(25);  // 
        delay(200);
        myservo4.write(130); //
        myservo5.write(60);  // 
        delay(100);
        myservoA0.write(10); // 
        myservoA1.write(50); //
        myservo12.write(20); // 
        myservo11.write(75);  //
        myservo3.write(130);
        delay(150);
        
        myservo2.detach();
        myservo8.detach(); // 
        myservo10.detach(); // 
        myservo9.detach(); // 
        myservo12.detach(); //
        myservo11.detach();  // 
        myservo6.detach(); // left right
        myservo7.detach();  // left right
        myservo4.detach(); // up down
        myservo5.detach();  // up down
        myservoA0.detach(); // 
        myservoA1.detach(); // 
        myservo3.detach();
      }
      else if(pos=='N') {
        // YELLING
        myservo6.attach(6); // 
        myservo7.attach(7);  // 
        myservo4.attach(4); // 
        myservo5.attach(5);  
        myservo10.attach(10); // 
        myservo9.attach(9);   // 
        //myservo12.attach(12); // 
        //myservo11.attach(11);  // 
        myservoA0.attach(A0); // 
        myservoA1.attach(A1);  // 
        myservo8.attach(8);
        myservo2.attach(2);
        myservo3.attach(3);
        
        myservo10.write(145);  // left lip down
        myservo9.write(18);  // right lip down
        myservo8.write(70);
        //myservo12.write(110); // left eyebrow sad
        //myservo11.write(80); // right eyebrow sad
        myservoA0.write(15);
        myservoA1.write(45);
        myservo6.write(25); // 
        myservo7.write(67);  // 
        myservo4.write(145);
        myservo5.write(60);
        myservo2.write(30);
        myservo3.write(170);
        delay(400);
        
        myservo10.detach(); //
        myservo9.detach(); //
        myservo8.detach();
        myservo2.detach();
        //myservo12.detach(); // 
        //myservo11.detach();  // 
        myservoA0.detach(); // 
        myservoA1.detach();  // 
        myservo6.detach(); // left right
        myservo7.detach();  // left right
        myservo4.detach(); // up down
        myservo5.detach();  // up down
        myservo3.detach();
      }
      else if(pos=='O') {
        // YAWN
        myservo2.attach(2);
        myservo6.attach(6); // 
        myservo7.attach(7);  // 
        myservo4.attach(4); // 
        myservo5.attach(5);  
        myservo10.attach(10); // 
        myservo9.attach(9);   //
        myservo12.attach(12); 
        //myservo12.attach(12); // 
        //myservo11.attach(11);  // 
        myservoA0.attach(A0); // 
        myservoA1.attach(A1);  // 
        myservo8.attach(8);
        myservo3.attach(3);
        
        myservo10.write(145);  // left lip down
        myservo9.write(18);  // right lip down
        myservo8.write(70);
        //myservo12.write(110); // left eyebrow sad
        //myservo11.write(80); // right eyebrow sad
        myservoA0.write(10);
        myservoA1.write(55);
        myservo6.write(25); // 
        myservo7.write(67);  // 
        myservo4.write(145);
        myservo5.write(60);
        myservo12.write(0);
        myservo2.write(115);
        delay(12000);
        myservo8.write(115);
        myservo3.write(100);
        delay(400);
        myservo2.detach();
        myservo10.detach(); //
        myservo9.detach(); //
        myservo8.detach();
        //myservo12.detach(); // 
        //myservo11.detach();  // 
        myservoA0.detach(); // 
        myservoA1.detach();  // 
        myservo6.detach(); // left right
        myservo7.detach();  // left right
        myservo4.detach(); // up down
        myservo5.detach();  // up down
        myservo12.detach();
        myservo3.detach();
       delay(300);
      }
      else if(pos=='P') {
        // BURP
        myservo2.attach(2);
        myservo6.attach(6); // 
        myservo7.attach(7);  // 
        myservo4.attach(4); // 
        myservo5.attach(5);  
        myservo10.attach(10); // 
        myservo9.attach(9);   //
        myservo12.attach(12); 
        //myservo12.attach(12); // 
        //myservo11.attach(11);  // 
        myservoA0.attach(A0); // 
        myservoA1.attach(A1);  // 
        myservo8.attach(8);
        myservo3.attach(3);
        
        myservo10.write(145);  // left lip down
        myservo9.write(18);  // right lip down
        myservo8.write(70);
        //myservo12.write(110); // left eyebrow sad
        //myservo11.write(80); // right eyebrow sad
        myservoA0.write(40);
        myservoA1.write(15);
        myservo6.write(25); // 
        myservo7.write(67);  // 
        myservo4.write(145);
        myservo5.write(60);
        myservo12.write(20);
        myservo2.write(115);
        delay(12000);
        myservo8.write(115);
        myservo3.write(130);
        delay(400);
        myservo2.detach();
        myservo10.detach(); //
        myservo9.detach(); //
        myservo8.detach();
        //myservo12.detach(); // 
        //myservo11.detach();  // 
        myservoA0.detach(); // 
        myservoA1.detach();  // 
        myservo6.detach(); // left right
        myservo7.detach();  // left right
        myservo4.detach(); // up down
        myservo5.detach();  // up down
        myservo12.detach();
        myservo3.detach();
      }
       else if(pos=='Q') {
        // LOOPY EYES        
        delay(200);
        myservo8.attach(8); //
        myservo10.attach(10); // 
        myservo9.attach(9); // 
        myservo12.attach(12); // 
        myservo11.attach(11);  //
        myservo6.attach(6); // 
        myservo7.attach(7);  // 
        myservo4.attach(4); // 
        myservo5.attach(5);  // 
        myservoA0.attach(A0); // 
        myservoA1.attach(A1); // 
        myservo2.attach(2);
        myservo3.attach(3);
        
        myservo8.write(90);  // 
        myservo10.write(100);  // 
        myservo9.write(120);  // 

        delay(100);
        myservo7.write(68);  //
        myservo6.write(25);  
        delay(100);  
        myservo6.write(80);// 
        myservo7.write(0); 
        delay(100);  
        myservo4.write(130); //
        myservo5.write(60);
        delay(100);  
        myservo4.write(35); //
        myservo5.write(0);
        delay(100);  
        myservo6.write(-60);// 
        myservo7.write(110); 
        delay(100);  
        myservo4.write(130); //
        myservo5.write(60);
      
        delay(100);
        myservoA0.write(40); // 
        myservoA1.write(15); //
        myservo12.write(20); // 
        myservo11.write(75);  //
        myservo2.write(100);
        myservo3.write(130);
        delay(250);
        
        myservo8.detach(); // 
        myservo10.detach(); // 
        myservo9.detach(); // 
        myservo11.detach();  // 
        myservo6.detach(); // 
        myservo7.detach();  // 
        myservo4.detach(); // 
        myservo5.detach();  // 
        myservoA0.detach(); // 
        myservoA1.detach(); // 
        myservo2.detach();
        myservo3.detach();
        delay(200);
      }
     if(pos=='R') {
        // ANIMATED TALKING
        myservoA0.attach(A0);   //
        myservoA1.attach(A1);   //
        myservo10.attach(10); // 
        myservo9.attach(9);   //
        myservo12.attach(12); // 
        myservo11.attach(11); //  
        myservo6.attach(6); // 
        myservo7.attach(7);  // 
        myservo4.attach(4); // 
        myservo5.attach(5);  // 
        myservo2.attach(2);
        myservo3.attach(3);
        
        myservo2.write(130);
        myservoA0.write(130);   //
        myservoA1.write(-20);   //
        myservo10.write(-5);  // 
        myservo9.write(180);   // 
        myservo12.write(10);   //
        myservo11.write(75);    // 
        myservo6.write(25); // 
        myservo7.write(67);  // 
        myservo4.write(130);
        myservo5.write(60);
        myservo3.write(115);
        delay(400);
        
        myservo2.detach(); 
        myservo10.detach();  // 
        myservo9.detach();   // 
        myservo12.detach();  //
        myservo11.detach();  // 
        myservoA0.detach();  //  
        myservoA1.detach();  //  
         myservo6.detach(); // 
        myservo7.detach();  // 
        myservo4.detach(); // 
        myservo5.detach();  //
       myservo3.detach(); 
      }
        else if(pos=='S') { 
        //NECK BACK TO NEUTRAL
        myservo11.attach(11);
        myservo6.attach(6);
        myservo7.attach(7);
        
        myservo11.write(75); 
        myservo6.write(25); // 
        myservo7.write(68);  // 
        delay(50);
        
        myservo11.detach();
        myservo6.detach();
        myservo7.detach();
      }
        else if(pos=='T') {
        // BLINK, TURN, BACK TO NEUTRAL
    
        myservoA0.attach(A0);
        myservoA1.attach(A1);
        myservoA0.write(0);
         myservoA1.write(70);
         delay(150);
        myservoA0.write(40); //open eyelid
         myservoA1.write(15);
         delay(150); 
         myservoA0.detach();
         myservoA1.detach();
         delay(100);
        myservo11.attach(11);
        myservoA0.attach(A0); //  
        myservoA1.attach(A1);
        myservoA0.write(40); //  
        myservoA1.write(15);
        myservo11.write(110);   // head right
        delay(250);
        myservo11.detach();
        myservoA0.detach(); //  
        myservoA1.detach();
        delay(4000);         
      }
    
    }
  } 
} 

