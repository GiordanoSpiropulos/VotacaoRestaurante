import { CardProps } from "../types";
import "./Card.css";

export default function Card(props: CardProps) {
  const isSelected = props.id === props.selectedCardId;

  const handleClick = () => {
    props.onCardClick(props.id);
  };

  return (
    <div
      className={`card ${isSelected ? "selected" : ""}`}
      onClick={handleClick}
    >
      <h3>{props.title}</h3>
    </div>
  );
}
