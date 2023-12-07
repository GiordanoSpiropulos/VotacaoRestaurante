import { useState, useEffect } from "preact/hooks";
import "./app.css";
import profissionalService from "./services/profissionalService";
import { Profissional, Restaurante } from "./types";
import restauranteService from "./services/restauranteService";
import handleApiResponse from "./helpers/handleApiResponse";
import Dropdown from "./components/dropdown/dropdown";
import { DropdownOptions } from "./components/types/dropdown.props";
import { Card } from "./components/types";
import CardContainer from "./components/card/cardContainer/cardContainer";
import votacaoService from "./services/votacaoService";

export function App() {
  const [error, setError] = useState<string>("");
  const [hasWinner, setHasWinner] = useState<boolean>(false);

  const [profissionais, setProfissionais] = useState<Profissional[]>([]);
  const [profissionaisDidntVote, setProfissionaisDidntVote] = useState<
    Profissional[]
  >([]);
  const [profissionaisDropdown, setProfissionaisDropdown] = useState<
    DropdownOptions[]
  >([]);
  const [profissionalSelected, setProfissionalSelected] = useState<number>(0);

  const [restaurantes, setRestaurantes] = useState<Restaurante[]>([]);
  const [restaurantesCardData, setRestaurantesCardData] = useState<Card[]>([]);
  const [restauranteSelected, setRestauranteSelected] = useState<number>(0);

  useEffect(() => {
    getAllProfissionais();
    getProfissionaisDidntVote();
    getAllRestaurantes();
  }, []);

  async function getAllProfissionais() {
    await profissionalService.getAll().then((res) => {
      handleApiResponse(
        res,
        (data) => {
          setProfissionais(data || []);
          let dropdownOptions: DropdownOptions[] = [];
          data?.map((profissional) => {
            dropdownOptions.push({
              label: profissional.nome,
              value: profissional.profissionalID,
            });
          });
          setProfissionaisDropdown(dropdownOptions);
        },
        (error) => {
          setError(error);
        }
      );
    });
  }

  async function getAllRestaurantes() {
    await restauranteService.getAll().then((res) => {
      handleApiResponse(
        res,
        (data) => {
          setRestaurantes(data || []);

          let cards: Card[] = [];
          data?.map((restaurante) => {
            cards.push({
              id: restaurante.restauranteID,
              title: restaurante.nome,
            });
          });
          setRestaurantesCardData(cards);
        },
        (error) => {
          setError(error);
        }
      );
    });
  }

  async function getProfissionaisDidntVote() {
    await votacaoService.getProfissionaisDidntVote().then((res) => {
      handleApiResponse(res, (data) => {
        setProfissionaisDidntVote(data!);
        if (data!.length <= 0) {
          getResultadoVotacao();
        }
      });
    });
  }

  async function getResultadoVotacao() {
    await votacaoService.getResult().then((res) => {
      handleApiResponse(res, (data) => {
        if (data) {
          let cards: Card[] = [];
          cards.push({ id: data.restauranteID, title: data.nome });
          setRestaurantesCardData(cards);
          setHasWinner(true);
        }
      });
    });
  }
  async function addVotacao() {
    setError("");
    await votacaoService
      .add({
        profissionalID: profissionalSelected,
        restauranteID: restauranteSelected,
      })
      .then(() => {
        let tempProfissionaisDidntVote = profissionaisDidntVote;
        let index = tempProfissionaisDidntVote.findIndex(
          (p) => p.profissionalID == profissionalSelected
        );
        tempProfissionaisDidntVote.splice(index, 1);

        if (tempProfissionaisDidntVote.length <= 0) getResultadoVotacao();
        setProfissionaisDidntVote([...tempProfissionaisDidntVote]);
      })
      .catch((ex) => {
        handleApiResponse(ex.response, undefined, (error) => {
          setError(error);
        });
      });
  }

  function onDropdownProfissionalSelect(profissionalSelected: number) {
    setProfissionalSelected(profissionalSelected);
  }
  function onCardClick(restauranteSelected: number) {
    if (hasWinner) return;
    setRestauranteSelected(restauranteSelected);
  }

  return (
    <main>
      <h1>CertFome</h1>
      {restaurantes?.length > 0 && profissionais!.length > 0 && (
        <>
          {!hasWinner ? (
            <>
              <Dropdown
                options={profissionaisDropdown}
                onOptionSelect={onDropdownProfissionalSelect}
                defaultText="Selecione um funcionário"
              />
              <div class="profissionaisDidntVote-container">
                <p>Profissionais restantes a votar:</p>
                {profissionaisDidntVote.map((profissional, index) => (
                  <p key={profissional.profissionalID}>
                    {(index ? ", " : "") + profissional.nome}
                  </p>
                ))}
              </div>
            </>
          ) : (
            <p>Temos um vencedor!</p>
          )}
          <CardContainer
            cards={restaurantesCardData}
            onCardClick={onCardClick}
          />
          {error && <p class="error">{error}</p>}
          {!hasWinner && (
            <button class="votarBtn" onClick={addVotacao}>
              Votar
            </button>
          )}
        </>
      )}
    </main>
  );
}
