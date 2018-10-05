int relay_pin = 4;
int led_pin = 13;
int incomingByte = 0;
void setup() 
{
  pinMode(relay_pin, OUTPUT);
  pinMode(led_pin, OUTPUT);
  digitalWrite(relay_pin, 0);
  digitalWrite(led_pin, 0);
  Serial.begin(9600);
}

void loop() 
{
  if(Serial.available())
  {
    incomingByte = Serial.read();
    if(incomingByte == 0xF0)
    {
      digitalWrite(relay_pin, 1);
      digitalWrite(led_pin, 1);
    }
    else if(incomingByte == 0xAA)
    {
      digitalWrite(relay_pin, 0);
      digitalWrite(led_pin, 0);
    }
  }
}
