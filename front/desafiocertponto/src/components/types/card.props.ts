export interface CardContainerProps {
  cards: CardProps[];
}

export interface CardProps {
  id: number;
  title: string;
  selectedCardId: number | null;
  onCardClick: (id: number) => void;
}

export interface CardData {
  cards: Card[];
  onCardClick: (id: number) => void;
}

export interface Card {
  id: number;
  title: string;
}
