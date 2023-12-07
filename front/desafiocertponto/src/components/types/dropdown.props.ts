export interface DropdownProps {
  options: DropdownOptions[];
  defaultText: string;
  onOptionSelect: (selectedOption: number) => void;
}

export interface DropdownOptions {
  label: string;
  value: number;
}
