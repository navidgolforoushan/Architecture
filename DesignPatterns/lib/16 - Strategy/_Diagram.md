```mermaid

---
title: Order
---
classDiagram
class ISendMessage
<<interface>> ISendMessage
ISendMessage : +SendMessage(msg)

class EmailMessageSenderService{
+SendMessage(msg)
}
class TextMessageSenderService{
+SendMessage(msg)
}

ISendMessage<|--EmailMessageSenderService
ISendMessage<|--TextMessageSenderService
class Order{
    -orders
    +AddOrder(item)
    +SendReceipt (messageSenderService)
}

Order..|>ISendMessage
```
https://mermaid.js.org/syntax/classDiagram.html