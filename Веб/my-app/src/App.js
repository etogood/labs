import 'bootstrap/dist/css/bootstrap.min.css';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <p>
          Hello, world!
        </p>

        <MyButton>

        </MyButton>
      </header>
    </div>
  );
}

function MyButton() {
  return (
    <button className="btn btn-primary">I'm a button</button>
  );
}

export default App;
