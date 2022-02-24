#include <IRremote.h>
int RECV_PIN = A0; // 입력값 핀 설정
IRrecv irrecv(RECV_PIN);
decode_results results;
void setup()
{
  Serial.begin(9600);
  irrecv.enableIRIn(); // 수신 시작
  pinMode(7, OUTPUT);//LED핀 설정
}
void loop() {
  if (irrecv.decode(&results)) {
    Serial.println(results.value, HEX);
   
   switch (results.value) {
        case 0xFF6897: digitalWrite(7, HIGH); break; //0버튼이 눌리면 LED ON
        case 0xFF30CF: digitalWrite(7, LOW); break; //1버튼이 눌리면 LED OFF
      }
    irrecv.resume(); // 다음 출력값 수신 준비
  }
}
