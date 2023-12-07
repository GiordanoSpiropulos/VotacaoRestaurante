import { useState } from "preact/hooks";
import Card from "../card";
import "../Card.css";
import { CardData } from "../../types";

export default function CardContainer(props: CardData) {
  const [selectedCardId, setSelectedCardId] = useState<number | null>(null);

  const handleCardClick = (id: number) => {
    setSelectedCardId(id);
    props.onCardClick(id);
  };

  return (
    <div className="card-container">
      {props.cards.map((card) => (
        <Card
          key={card.id}
          id={card.id}
          title={card.title}
          selectedCardId={selectedCardId}
          onCardClick={handleCardClick}
        />
      ))}
    </div>
  );
}
