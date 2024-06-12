```mermaid
---
title: Pokemon Game Class Diagram
---
classDiagram
Items<|-- Ball
Items<|--Potions
Items: -string name
Items: -int price
Items: +ToString()

Ball{
  - double rate
  -int ball_value
  -int max_RDN
  -bool isMaster
  + bool Catch()
}
Potions{
  PotionType type
}





```
