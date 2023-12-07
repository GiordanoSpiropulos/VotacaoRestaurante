import { useState } from "preact/hooks";
import "./dropdown.css";
import { DropdownProps } from "../types/dropdown.props";

export default function Dropdown(props: DropdownProps) {
  const [isOpen, setIsOpen] = useState(false);
  const [selectedOption, setSelectedOption] = useState<string | null>(null);

  const toggleDropdown = () => {
    setIsOpen(!isOpen);
  };

  const handleOptionClick = (option: string, value: number) => {
    setSelectedOption(option);
    setIsOpen(false);
    props.onOptionSelect(value);
  };

  return (
    <div className="dropdown">
      <button className="dropdown-toggle" onClick={toggleDropdown}>
        {selectedOption || props.defaultText}
      </button>
      <ul className={`dropdown-menu ${isOpen ? "show" : ""}`}>
        {props.options.map((option, index) => (
          <li
            key={index}
            className="dropdown-item"
            onClick={() => handleOptionClick(option.label, option.value)}
          >
            {option.label}
          </li>
        ))}
      </ul>
    </div>
  );
}
