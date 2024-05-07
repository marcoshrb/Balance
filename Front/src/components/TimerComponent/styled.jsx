import styled from 'styled-components';

const TimerWrapper = styled.div`
  font-family: Arial, sans-serif;
  text-align: center;
  justify-content: center;
  align-items: center;
  margin-top: 8em;
`;

const CronometroDisplay = styled.div`
  font-size: 16em;
`;

const AcoesWrapper = styled.div`
`;

const Embaixo = styled.div`
  margin-top: 12.9em;
`;

const StartButton = styled.a`
  display: inline-block;
  align-content: center;
  margin-right: 20px;
  padding: 10px 20px;
  background-color: #4CAF50;
  color: white;
  text-decoration: none;
  font-size: 2.3em; 
  cursor: pointer;
  border-radius: 10px;
  height: 1.2em;
  width: 4em;
  &:hover {
    background-color: #45a049;
  }

  &.pause {
    background-color: #f44336;
    &:hover {
      background-color: #d32f2f;
    }
  }
`;

const EscButton = styled.a`
  display: inline-block;
  align-content: center;
  padding: 10px 20px;
  background-color: #f44336;
  color: white;
  text-decoration: none;
  font-size: 2.3em; 
  cursor: pointer;
  border-radius: 10px;
  height: 1.2em;
  width: 4em;
  &:hover {
    background-color: #d32f2f;
  }
`;

export { TimerWrapper, CronometroDisplay, AcoesWrapper, Embaixo, StartButton, EscButton };
