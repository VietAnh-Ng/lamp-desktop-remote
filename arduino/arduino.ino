int relay_pin = 4;
int incomingByte = 0;
void setup() 
{
  pinMode(relay_pin, OUTPUT);
  Serial.begin(9600);
}

void loop() {
  if(Serial.available())
  {
    incomingByte = Serial.read();
    if(incomingByte == 0xF0)
    {
      digitalWrite(relay_pin, 0);
    }
    else if(incomingByte == 0xAA)
    {
      digitalWrite(relay_pin, 1);
    }
  }
}
