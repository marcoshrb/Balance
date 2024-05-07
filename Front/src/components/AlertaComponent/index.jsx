import { useContext } from "react";
import { Alert } from "react-bootstrap";
import { AlertaContext } from "../../context/alerta";
import styles from './styles.module.scss';

export default function AlertaComponent(){
    const { message, variant, show, setShow } = useContext(AlertaContext);
        return(
        <Alert
            show={show}
            variant={variant}
            onClose={() => setShow(false)}
            dismissible
        >
            <p className={styles.alert}>{message}</p>
        </Alert>
    )
}