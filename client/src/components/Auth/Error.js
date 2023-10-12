import "./styles.css";
import React from "react";
import PropTypes from "prop-types";

const Error = ({ showIf, children }) =>
    showIf ? <div className="error">{children}</div> : false;

Error.defaultProps = {
    showIf: false
};

Error.propTypes = {
    showIf: PropTypes.bool
};

export default Error;